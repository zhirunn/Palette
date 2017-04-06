using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchType1 : MonoBehaviour {
    public GameObject door;
    public GameObject[] switches;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }

        //Open door if only one switch
        if (switches.Length == 0)
        {
            door.GetComponent<BoxCollider2D>().isTrigger = true;

            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;

            return;
        }

        //Check pattern
        pattern1();

        //Open door if last switch is disabled
        if (!switches[switches.Length - 1].GetComponent<Switches>().getState())
        {
            door.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void pattern1()
    {
        int counter = 0;

        //Find the switch from the swithc list
        foreach (GameObject item in switches)
        {
            //All previous in proper order
            if (item.name == this.name)
            {    
                break;
            }

            counter++;
        }
        
        //First object
        if(counter == 0)
        {
            //Disable
            switches[0].GetComponent<Switches>().disable();
            return;
        }

        for (int i = 0; i <= counter - 1; i++)
        {
            //Check if enabled. If so enable everything and reset
            if(switches[i].GetComponent<Switches>().getState())
            {
                foreach(GameObject item in switches) {
                    item.GetComponent<Switches>().enable();
                }
                return;
            }
        }

        switches[counter].GetComponent<Switches>().disable();
        return;
    }

}
