﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDestroyer : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }

        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Enemy");
            
        foreach (GameObject monster in monsters)
        {
            Destroy(monster);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }
        //Turn off trigger and turn on collider
        //this.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}