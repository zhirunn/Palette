using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoneStop : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Reward")
        {
            col.transform.parent = this.transform;
            col.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}
