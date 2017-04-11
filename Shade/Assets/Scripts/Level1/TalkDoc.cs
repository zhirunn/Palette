using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkDoc : MonoBehaviour
{
    public GameObject doctor;
    public GameObject door;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!doctor.GetComponent<SpriteRenderer>().enabled)
        {
            door.AddComponent<LevelChange>().levelName = "Level1Pt2";
        }
    }
}
