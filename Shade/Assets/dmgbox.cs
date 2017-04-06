using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgbox : MonoBehaviour {
    public Player p;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            p.LoseHealth(5);
        }
    }
}
