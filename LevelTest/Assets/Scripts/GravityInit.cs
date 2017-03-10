using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityInit : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Physics.gravity = new Vector3(0f, 0f, -9.81f);
    }
}
