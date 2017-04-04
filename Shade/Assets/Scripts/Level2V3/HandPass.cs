using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPass : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Window")
        {
            coll.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
            
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Window")
        {
            coll.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

    }
}
