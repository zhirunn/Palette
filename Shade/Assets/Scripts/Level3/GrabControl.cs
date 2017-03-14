using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabControl : MonoBehaviour {

    public Player player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "reward") {
            if (col.name == "HP_portion") {
                player.health += 5;
            }
            Destroy(col, 0.1f);
        }

    }
    
}
