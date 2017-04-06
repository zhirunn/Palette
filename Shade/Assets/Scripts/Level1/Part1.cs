using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part1 : MonoBehaviour {
    public GameObject doors;
    public GameObject fakeDoors;
    public GameObject walls;
    public GameObject monsterDestroy;

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
            collider.isTrigger = false;
        }
        foreach (BoxCollider2D collider in walls.GetComponentsInChildren<BoxCollider2D>())
        {
            collider.enabled = true;
            collider.isTrigger = false;
        }

        //Enable triggers
        foreach (PolygonCollider2D collider in fakeDoors.GetComponentsInChildren<PolygonCollider2D>())
        {
            collider.isTrigger = true;
        }

        //Enable trigger for monster destruction
        monsterDestroy.GetComponent<BoxCollider2D>().enabled = true;
        monsterDestroy.GetComponent<BoxCollider2D>().isTrigger = true;

        //Disable this object
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

}
