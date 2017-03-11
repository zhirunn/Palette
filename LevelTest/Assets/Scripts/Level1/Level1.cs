using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour {
    public GameObject room1;
    public GameObject room2;
    public GameObject room3;
    public GameObject room4;
    public GameObject doors;

	// Use this for initialization
	void Start () {
        disableSprite(room1);
        disableSprite(room2);
        disableSprite(room3);
        disableSprite(room4);
        disableSprite(doors);
    }

    // Update is called once per frame
    void Update()
    {
        //Show doors to rooms
        //Remove wall beneath the door or turn off collider
        if (Input.GetButtonDown("Vision"))
        {

        }
    }

    //Disable sprite renderers of all child objects
    void disableSprite(GameObject obj)
    {
        foreach (SpriteRenderer renderer in obj.GetComponentsInChildren<SpriteRenderer>())
        {
            renderer.enabled = false;
        }
    }
}
