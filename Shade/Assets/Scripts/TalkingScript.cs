using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingScript : MonoBehaviour {

	public TwineTextPlayer textPlayer;

	bool _Seetext = false;

	void OnTriggerEnter2D(Collider2D other) {
   	//characterInRange = true;
	}
	
	void Update(){
		bool BtnPressed = Input.GetButtonDown("TwineText");
		if(BtnPressed) {
			_Seetext = true;
		}
		if(_Seetext == true) {
			textPlayer.gameObject.SetActive(true);
			//textPlayer.gameObject.GetComponent<TwineTextPlayer>().StartStory = true;
		}
		else{
			textPlayer.gameObject.SetActive(false);
		}
	}
		
	
}
