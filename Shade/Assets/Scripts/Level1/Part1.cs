using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part1 : MonoBehaviour {
    public GameObject doors;
    public GameObject fakeDoors;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }

        //Disable doors
        foreach (SpriteRenderer renderer in doors.GetComponentsInChildren<SpriteRenderer>())
        {
            renderer.enabled = false;
        }
        foreach (BoxCollider2D collider in doors.GetComponentsInChildren<BoxCollider2D>())
        {
            collider.enabled = false;
        }

        //Enable triggers
        foreach (PolygonCollider2D collider in fakeDoors.GetComponentsInChildren<PolygonCollider2D>())
        {
            collider.isTrigger = true;
        }

        this.GetComponent<SpriteRenderer>().enabled = false;
    }

}
