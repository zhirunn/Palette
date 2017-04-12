using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossInteractable : Interactable
{
    private GameObject[] phoneParts;
    private int numParts = 0;

    public void Start()
    {
        phoneParts = GameObject.FindGameObjectsWithTag("Reward");

        numParts = phoneParts.Length;
        Completed = true;
    }

    public int PhonePartRetrieved(int numberRetrieved=1)
    {
        numParts -= numberRetrieved;

        if (numParts == 0)
        {
            Passage = "Ifspokentoafterobtainingparts";
            Completed = false;
        }

        return numParts;
    }

}
