using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Handles just the part about the headaches

*/
public class Headache : MonoBehaviour
{
    public GameObject monster;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            monster.GetComponent<SpriteRenderer>().enabled = true;


            //Dialouge
            print("Oh no. Monster!");

            //Headache
            print("Ow. Headache");

            //Reminder to activate
            print("Press Z to activate ability!");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.GetComponent<Collider2D>().enabled = false;
        }
    }
}
