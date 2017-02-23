using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Handles just the inital story
*/
public class InitialStory : MonoBehaviour {

    public GameObject doc;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Dialouge here
        print("Dialouge Here");

        //Move Dr.Evian out the door
        //Play sounds
    }

    void OnTriggerExit2D(Collider2D other)
    {
        this.GetComponent<Collider2D>().enabled = false;
    }
}
