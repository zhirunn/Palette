using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject, 0.7f);
    }
}
