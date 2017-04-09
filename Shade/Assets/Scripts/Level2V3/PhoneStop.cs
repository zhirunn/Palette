using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneStop : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Reward")
        {
            col.transform.parent = this.transform;
            col.GetComponent<CircleCollider2D>().isTrigger = false;
            col.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
