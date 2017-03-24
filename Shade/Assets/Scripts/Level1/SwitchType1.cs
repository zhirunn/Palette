using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchType1 : MonoBehaviour {
    public GameObject door;
    public GameObject[] switches;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }

        if (switches.Length == 0)
        {
            door.GetComponent<BoxCollider2D>().isTrigger = true;

            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;

            return;
        } 

        /*
        //First trigger
        if(switches[0].name == this.name) 
        {
            switches[0].GetComponent<SpriteRenderer>().enabled = false;
            switches[1].GetComponent<CircleCollider2D>().enabled = true;
            switches[1].GetComponent<CircleCollider2D>().isTrigger = true;
        }
        */

        //Check pattern
        pattern1();
    }

    void pattern1()
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
        print(counter);
        counter = counter - 1;
        //Check previous are all disabled
        for(int i = 0; i < counter; i++)
        {
            if (!switches[i].GetComponent<SpriteRenderer>().enabled == false)
            {
                foreach (GameObject item in switches)
                {
                    item.GetComponent<CircleCollider2D>().enabled = true;
                    item.GetComponent<SpriteRenderer>().enabled = true;

                    counter = 0;
                    return;
                }
            }
        }

        //All previous switches pressed in the right order
        this.GetComponent<CircleCollider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

}
