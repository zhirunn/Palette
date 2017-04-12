using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part2 : MonoBehaviour
{
    public GameObject monsterDestroy;
    public GameObject wall;
    public GameObject[] props;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }

        //Enable trigger for monster destruction
        monsterDestroy.AddComponent<MonsterDestroyer>();
        monsterDestroy.GetComponent<MonsterDestroyer>().roomName = "Room2Tests";
        monsterDestroy.GetComponent<MonsterDestroyer>().wall = wall;
        monsterDestroy.GetComponent<MonsterDestroyer>().props = props;

        //wall.GetComponent<BoxCollider2D>().enabled = true;
        //wall.GetComponent<BoxCollider2D>().isTrigger = true;

        //Disable this key
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
    }
}
