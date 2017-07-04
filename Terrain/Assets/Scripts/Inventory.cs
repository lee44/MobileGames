using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour 
{
	public static int charge = 0;
	public AudioClip collectSound;
	public Texture2D[] hudCharge;
	public GUITexture chargeHudGUI;
	public Texture2D[] meterCharge;
	public Renderer meter;
	bool haveMatches = false;
	public GUITexture matchGUIprefab;
	GUITexture matchGUI;
	ParticleEmitter[] fireEmitters;
	public GUIText textHints;
	public GameObject winObj;

	void Start () 
	{
		charge = 0;
	}
	void CellPickup()
	{
		HUDon();
		charge++;
		chargeHudGUI.texture = hudCharge[charge];
		//meter.material.mainTexture changes the texture of the chargeMeter's material. Remember a texture goes on a material!!!
		meter.material.mainTexture = meterCharge[charge];
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
	}
	void HUDon()
	{
		if(!chargeHudGUI.enabled)
		{
			chargeHudGUI.enabled = true;
		}
	}
	void MatchPickup()
	{
		haveMatches = true;
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		//campfireHintReceived = true;
		//Instantiate creates a object and "as GUITexture" set the type of that object
		matchGUI = Instantiate(matchGUIprefab,new Vector3(0.15f, 0.1f, 0),transform.rotation) as GUITexture; 
	}
	void OnControllerColliderHit(ControllerColliderHit col)
	{
		if(col.gameObject.name == "campfire")
		{	
			if(haveMatches)
				LightFire(col.gameObject);
			else
				textHints.SendMessage("ShowHint","I could use this campfire to signal for help..if only I could light it..");
		}
	}
	void LightFire(GameObject campfire)
	{
		fireEmitters = campfire.GetComponentsInChildren<ParticleEmitter>(); //GetComponentsInChildren returns an array of ParticleEmitter
		
		foreach(ParticleEmitter emitter in fireEmitters)
			emitter.emit = true;

		campfire.GetComponent<AudioSource>().Play();
		Destroy(matchGUI);
		winObj.SendMessage("GameOver");
		
	}
}
