using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkDoc : MonoBehaviour
{
    public GameObject doctor;
    public GameObject door;

    void OnTriggerStay2D(Collider2D other)
    {
        bool isLevelChangeNotAddedYet = door.GetComponent<Interactable>() == null;
        if(!doctor.GetComponent<SpriteRenderer>().enabled && isLevelChangeNotAddedYet)
        {
            door.AddComponent<Interactable>().Passage = "LeaveLevel1";
        }
    }
}
