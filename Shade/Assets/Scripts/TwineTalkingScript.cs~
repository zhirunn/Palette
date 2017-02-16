using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwineTalkingScript : MonoBehaviour {

	public TwineTextPlayer textPlayer;
	bool characterInRange = false;
	bool _Seetext = false;
	//bool _CanTalk = false;

	void OnTriggerEnter2D(Collider2D other) {
		if(other.name == "girl") {
   		characterInRange = true;
   	}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if(other.name == "girl") {
   		characterInRange = false;
   	}
	}
	
	void Update() {
		//This is some code that I tried to use to get characters to face each other when they talk with one another.
		//var player = GameObject.Find("professor");
		//var otherthing = GameObject.Find("girl");
		//var otherthingForward = otherthing.transform.TransformDirection(Vector3.forward);		
		//var playerForward = player.transform.TransformDirection(Vector3.forward);
		//var dotProduct = Vector3.Dot(otherthingForward, playerForward);
		
		//if(dotProduct < -0.8){
		//		_CanTalk = true;
		//}



		bool BtnPressed = Input.GetButtonDown("TwineText");
		if(characterInRange == false) {
			_Seetext = false;		
		}
		if((BtnPressed) && (characterInRange == true)) {
			_Seetext = true;
		}
		if(_Seetext == true) {
			textPlayer.gameObject.SetActive(true);
			//textPlayer.gameObject.GetComponent<TwineTextPlayer>().StartStory = true;
		}
		else if(_Seetext == false) {
			textPlayer.gameObject.SetActive(false);
		}
	}
}

