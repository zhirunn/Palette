using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour {
    public GameObject room1;
    public GameObject room2;
    public GameObject room3;
    public GameObject doors;

    public GameObject phoneParts;
    public GameObject newLevelDoor;

    private bool added = false;

    // Use this for initialization
    void Start () {
        //disableSprite(room1);
        //disableSprite(room2);
        //disableSprite(room3);
        //disableSprite(doors);
    }

    // Update is called once per frame
    void Update()
    {

        if (!added)
        {
            //Enable level two if conditions met
            nextLevel();
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

    //Checks and gets level two ready
    void nextLevel()
    {
        foreach (SpriteRenderer part in phoneParts.GetComponentsInChildren<SpriteRenderer>())
        {
            if(part.enabled)
            {
                return;
            }
        }

        //No phoneparts are left, next level enabled
        newLevelDoor.GetComponent<BoxCollider2D>().isTrigger = true;
        LevelChange changeLevel = newLevelDoor.AddComponent<LevelChange>();
        changeLevel.levelName = "Level2V3";
        added = true;
    }
}
