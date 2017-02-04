/*
   Camera Controller for Prototype

    Ensures the camera follows the movement of the player

    William Thoang
    01-30-2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //Variables
    public GameObject player;
    private Vector3 offset;

	//Initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	//Updates after the player has moved
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
