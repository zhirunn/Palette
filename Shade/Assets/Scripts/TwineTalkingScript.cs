using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwineTalkingScript : MonoBehaviour {

	public TwineTextPlayer textPlayer;
	bool characterInRange = false;
	bool _Seetext = false;

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
	
	void Update(){
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
