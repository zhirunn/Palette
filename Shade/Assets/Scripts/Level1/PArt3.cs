using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PArt3 : MonoBehaviour {

    public GameObject monsterDestroy;
    public GameObject otherPart;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }

        //Disable this key
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;

        if (!otherPart.GetComponent<SpriteRenderer>().enabled) {
            //Enable trigger for monster destruction
            monsterDestroy.GetComponent<BoxCollider2D>().enabled = true;
            monsterDestroy.GetComponent<BoxCollider2D>().isTrigger = true;
        }   
    }
}
