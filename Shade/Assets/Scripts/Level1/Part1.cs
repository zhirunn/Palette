using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part1 : MonoBehaviour {
    public GameObject doors;
    public GameObject fakeDoors;
    public GameObject walls;
    public GameObject monsterDestroy;
    public GameObject wall;

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
        foreach (Transform obj in walls.GetComponentInChildren<Transform>())
        {
            obj.tag = "Untagged";
        }
        foreach (SpriteRenderer collider in walls.GetComponentsInChildren<SpriteRenderer>())
        {
            collider.enabled = true;
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
        monsterDestroy.AddComponent<MonsterDestroyer>();
        monsterDestroy.GetComponent<MonsterDestroyer>().roomName = "Room1Tests";
        wall.GetComponent<BoxCollider2D>().isTrigger = true;
        monsterDestroy.GetComponent<MonsterDestroyer>().wall = wall;

        //Disable this object
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

}
