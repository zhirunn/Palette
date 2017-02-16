using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler : MonoBehaviour {
    public GameObject toUnlock;

    /*
       If a player collides with this key, allow player to walk through specified game object
       Done by destroying the collider on the object to unlock
   */
    void OnTriggerEnter2D(Collider2D other)
    {
        this.GetComponent<SpriteRenderer>().enabled = false; 
        toUnlock.GetComponent<BoxCollider2D>().enabled = false;
    }
}
