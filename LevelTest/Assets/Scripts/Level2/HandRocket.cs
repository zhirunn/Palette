using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRocket : MonoBehaviour {

    public GameObject Hand;

	// Use this for initialization
	void Start () {
		// Hand = Find("HarpoonHand")
        // Hand.setActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput();
	}

    void HandleInput() {

        if (Input.GetKeyUp("fire2")) {

        }
    }
}
