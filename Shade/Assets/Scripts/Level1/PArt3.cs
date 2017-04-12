using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PArt3 : MonoBehaviour {

    public GameObject monsterDestroy;
    public GameObject otherPart;
    public GameObject wall;
    public GameObject[] props;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }

        //Disable this key
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;

        if (!otherPart.GetComponent<SpriteRenderer>().enabled) {
            //Enable trigger for monster destruction
            monsterDestroy.AddComponent<MonsterDestroyer>();
            monsterDestroy.GetComponent<MonsterDestroyer>().roomName = "Room3Tests";
            monsterDestroy.GetComponent<MonsterDestroyer>().wall = wall;
            monsterDestroy.GetComponent<MonsterDestroyer>().props = props;
            //monsterDestroy.GetComponent<BoxCollider2D>().enabled = true;
            //monsterDestroy.GetComponent<BoxCollider2D>().isTrigger = true;
        }   
    }
}
