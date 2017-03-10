/*
    Game Mechanic for Prototype

    Display the footprints and the door that leads to the next level 
        upon pressing key for a set amount of time.

    William Thoang
    01-30-2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
public class GameMechanic : MonoBehaviour {

    //Variables
    private int timeLeft;
    private GameObject[] footprint;

	//Initialization
	void Start () {
        footprint = GameObject.FindGameObjectsWithTag("Footprint");             //Finds all objects with specified tag
        timeLeft = 2;   //Time in seconds
        setState();     //Set beginning state
    }
	
    
	//Update
	void Update () {
        //Presses the key
        if (Input.GetKeyUp("k")) {
            setState(true);                 //Displays all objects
            StartCoroutine(timer());        //Creates a parallel action
        }
	}
    

    /*
        Object will disappear after the time limit expires
    */
    IEnumerator timer()
    {
        yield return new WaitForSeconds(timeLeft);
        setState();
    }

    /*
        Swaps state of all footprint objects

        Param:
            - state (used to set state of a game object)
    */
    public void setState(bool state = false) {
        for(int i = 0; i < footprint.Length; i++) {
            footprint[i].gameObject.SetActive(state);
        }
    }
}