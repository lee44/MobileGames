﻿#if UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)

namespace UnityEngine.Advertisements {
  using UnityEngine;
  using System.Collections;
  using System.Collections.Generic;

	internal class UnityAdsEditor : UnityAdsPlatform {
  	private static bool initialized = false;
  	private static bool ready = false;
		private UnityAdsEditorPlaceholder placeHolder = null;
    public override void init (string gameId, bool testModeEnabled, string gameObjectName, string unityVersion) {
	    if(initialized) return;
    	initialized = true;

      Utils.LogDebug ("UnityEditor: init(), gameId=" + gameId + ", testModeEnabled=" + testModeEnabled + ", gameObjectName=" + gameObjectName);

    	string url = "https://impact.applifier.com/mobile/campaigns?platform=editor&gameId=" + WWW.EscapeURL(gameId) + "&unityVersion=" + WWW.EscapeURL(unityVersion);
    	
		AsyncExec.runWithCallback<string,WWW> (getAdPlan, url, handleResponse);
  	}

	private IEnumerator getAdPlan(string url, System.Action<WWW> callback) {
		WWW www = new WWW(url);
			
		yield return www;
			
		callback(www);
	}


  	private void handleResponse(WWW www) {
	  bool success = false;

      if(!string.IsNullOrEmpty(www.error)) {
        Utils.LogError("UnityAdsEditor error: Failed to contact server");
      } else {
      string json = System.Text.Encoding.UTF8.GetString(www.bytes, 0, www.bytes.Length);
        
      bool validResponse = false;
        
      object parsedData = MiniJSON.Json.Deserialize(json);
      if(parsedData is Dictionary<string,object>) {
        Dictionary<string,object> parsedJson = (Dictionary<string,object>)parsedData;
        if(parsedJson.ContainsKey("status")) {
          string value = (string)parsedJson["status"];
          if(value.Equals("ok")) {
            validResponse = true;
          } else {
            if(parsedJson.ContainsKey("errorMessage")) {
                Utils.LogError("UnityAdsEditor error: Server returned error message: " + (string)parsedJson["errorMessage"]);
            }
          }
        } else {
            Utils.LogError("UnityAdsEditor error: JSON response does not have status field: " + json);
        }
      } else {
          Utils.LogError("UnityAdsEditor error: unable to parse JSON: " + json);
      }
        
      if(validResponse) {
        success = true;
      } else {
          Utils.LogError("UnityAdsEditor error: Failed to fetch campaigns");
      }
    }
    
    if(success) {
      UnityAds.SharedInstance.onFetchCompleted();
	    ready = true;
    } else {
      UnityAds.SharedInstance.onFetchFailed();
    }
  }

    public override bool show (string zoneId, string rewardItemKey, string options) {
      Utils.LogDebug ("UnityEditor: show()");
			GameObject placeHolderObject = GameObject.Find(@"UnityAdsEditorPlaceHolderObject");
			if (placeHolderObject == null) {
				placeHolderObject = new GameObject(@"UnityAdsEditorPlaceHolderObject");
				placeHolder = placeHolderObject.AddComponent<UnityAdsEditorPlaceholder>();
				placeHolder.init();
			}
			placeHolder.Show();
      return true;
    }
    
    public override void hide () {
      Utils.LogDebug ("UnityEditor: hide()");
    }
    
    public override bool isSupported () {
      Utils.LogDebug ("UnityEditor: isSupported()");
      return false;
    }
    
    public override string getSDKVersion () {
      Utils.LogDebug ("UnityEditor: getSDKVersion()");
      return "EDITOR";
    }
    
    public override bool canShowZone (string zone) {
      return ready;
    }
    
    public override bool hasMultipleRewardItems () {
      Utils.LogDebug ("UnityEditor: hasMultipleRewardItems()");
      return false;
    }
    
    public override string getRewardItemKeys () {
      Utils.LogDebug ("UnityEditor: getRewardItemKeys()");
      return "";
    }
    
    public override string getDefaultRewardItemKey () {
      Utils.LogDebug ("UnityEditor: getDefaultRewardItemKey()");
      return "";
    }
    
    public override string getCurrentRewardItemKey () {
      Utils.LogDebug ("UnityEditor: getCurrentRewardItemKey()");
      return "";
    }
    
    public override bool setRewardItemKey (string rewardItemKey) {
      Utils.LogDebug ("UnityEditor: setRewardItemKey() rewardItemKey=" + rewardItemKey);
      return false;
    }
    
    public override void setDefaultRewardItemAsRewardItem () {
      Utils.LogDebug ("UnityEditor: setDefaultRewardItemAsRewardItem()");
    }
    
    public override string getRewardItemDetailsWithKey (string rewardItemKey) {
      Utils.LogDebug ("UnityEditor: getRewardItemDetailsWithKey() rewardItemKey=" + rewardItemKey);
      return "";
    }
    
    public override string getRewardItemDetailsKeys () {
      return "name;picture";
    }

    public override void setLogLevel(Advertisement.DebugLevel logLevel) {
      Utils.LogDebug ("UnityEditor: setLogLevel() logLevel=" + logLevel);
    }
  }
}

#endif
