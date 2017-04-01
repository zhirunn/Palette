using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv3IntroDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col) {
        
        Application.LoadLevel("Level3Finale");
    }
}
