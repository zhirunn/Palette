using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timetest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput();
    }
    private void HandleInput() {
        if (Input.GetKey(KeyCode.Space)) {
            Time.timeScale = 0.5f;
        }
        if (Input.GetKey(KeyCode.S)) {
            Time.timeScale = 1f;
        }
        Time.fixedDeltaTime = 0.02f * Time.deltaTime;
    }
}
