using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public GameObject phoneParts;

    void OnCollisionEnter2D(Collision2D coll)
    {
        try
        {
            phoneParts.GetComponentInChildren<BoxCollider2D>().enabled = false;
        } catch
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
