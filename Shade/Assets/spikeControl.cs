using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeControl : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        speed = 3f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -Time.deltaTime * speed, 0);
    }
}
