﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingScript : MonoBehaviour {

	public TwineTextPlayer textPlayer;

	bool _Stext = false;

	void OnTriggerEnter2D(Collider2D other) {
   	//characterInRange = true;
	}
	
	void Update(){
		bool seeText = Input.GetButtonDown("TwineText");
		if(seeText) {
			_Stext = true;
		}
		if(_Stext) {
			textPlayer.gameObject.SetActive(true);
		}
	}
		
	
}
