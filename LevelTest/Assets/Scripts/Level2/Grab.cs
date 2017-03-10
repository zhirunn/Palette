using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour {
    public Transform hand;
    // Use this for initialization
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Reward")
        {
            col.transform.parent = hand;
        }
    }
    void OnTriggerStay2D(Collider2D col) {
        // Debug.Log("I am staying within a trigger");
        
    }
}
