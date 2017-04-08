using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2PhoneHandler : MonoBehaviour
{
    public GameObject[] phoneParts;
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }

        //Check pattern
        pattern1();

        //Open door if last switch is disabled
        if (!phoneParts[phoneParts.Length - 1].GetComponent<Switches>().getState())
        {
            door.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    void pattern1()
    {
        {
            int counter = 0;

            //Find the part from the list of all parts
            foreach (GameObject item in phoneParts)
            {
                //All previous in proper order
                if (item.name == this.name)
                {
                    break;
                }

                counter++;
            }

            //First object
            if (counter == 0)
            {
                //Disable
                phoneParts[0].GetComponent<Switches>().disable();
                return;
            }

            for (int i = 0; i <= counter - 1; i++)
            {
                //Check if enabled. If so enable everything and reset
                if (phoneParts[i].GetComponent<Switches>().getState())
                {
                    foreach (GameObject item in phoneParts)
                    {
                        item.GetComponent<Switches>().enable();
                    }
                    return;
                }
            }

            phoneParts[counter].GetComponent<Switches>().disable();
            return;
        }

    }
}
