using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour {

    // Use this for initialization
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "door") {
            
            Destroy(col.gameObject, 0.3f);
            Destroy(this.gameObject, 0.1f);
        }
    }
    
}
