using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : MonoBehaviour {
    public GameObject spawner;
    public GameObject enemyToSpawn;
    public int totalEnemy;
    public Transform[] spawnPoints;
    public GameObject passThrough;

    private Transform[] temp;
    private GameObject phonePart;

    public GameObject[] phoneParts;
    private float speed; // = 1.0F;
    private int dispo;// = 50;

void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }

        phonePart = GameObject.Find("phonePart (1)");

        //Do not run this script is phone part is picked up
        if (this.CompareTag("FakeDoor")) {
            if(phonePart.GetComponent<SpriteRenderer>().enabled == true)
            {
                return;
            }
        }/* else
        {
            if (phonePart.GetComponent<SpriteRenderer>().enabled == false)
            {
                return;
            }
        }
        */
        speed = (float)((Random.Range(30, 50)) / 100.0F);
        dispo = other.GetComponent<Player>().disposition.disposition;
        if (dispo >= 50)
        {
            dispo = Random.Range(0, 49);
        }
        else
        {
            dispo = Random.Range(75, 100);
        }

        for (int i = 0; i < totalEnemy; i++)
        {
            Spawn enemySpawn = spawner.GetComponent<Spawn>();         
            enemySpawn.GetComponent<Spawn>().setEnemy(enemyToSpawn);

            temp = new Transform[3];

            //Set enemy patrol path
            int mark1 = Random.Range(0, spawnPoints.Length);
            int mark2 = Random.Range(0, spawnPoints.Length);
            int mark3 = Random.Range(0, spawnPoints.Length);

            //Choose patrol path
            while((mark1 == mark2) && (mark2 == mark3))
            {
                mark1 = Random.Range(0, spawnPoints.Length);
                mark2 = Random.Range(0, spawnPoints.Length);
            }

            //Set markers
            temp[0] = spawnPoints[mark1];
            temp[1] = spawnPoints[mark2];
            temp[2] = spawnPoints[mark3];

            /*
            temp.SetValue((Transform)spawnPoints.GetValue(0), 0);
            temp.SetValue((Transform)spawnPoints.GetValue(1), 1);
            temp.SetValue((Transform)spawnPoints.GetValue(2), 2);
            */

            enemySpawn.setEnemyMarkers(temp);

            roomMod(other);

            //Set enemy disposition
            enemySpawn.setDisposition(dispo);

            //Set enemy at random speed
            enemySpawn.setSpeed(speed);

            //Cycle through spawn points to spawn monsters.
            if (i >= spawnPoints.Length) {
                enemySpawn.GetComponent<Spawn>().setSpawnPoint(spawnPoints[i % spawnPoints.Length]);
            }
            else
            {
                enemySpawn.GetComponent<Spawn>().setSpawnPoint(spawnPoints[i]);
            }

            enemySpawn.GetComponent<Spawn>().spawn();
        }

        passThrough.GetComponent<BoxCollider2D>().enabled = false;

        if (this.CompareTag("FakeDoor"))
        {
            this.GetComponent<PolygonCollider2D>().enabled = false;
        }
        else
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }

    private void roomMod(Collider2D other)
    {
        //Check if part 2 has been picked up
        if (!phoneParts[0].GetComponent<SpriteRenderer>().enabled)
        {
            //Picked up
            speed = (float)((Random.Range(75, 110)) / 100.0F);
            dispo = other.GetComponent<Player>().disposition.disposition;
            if (dispo >= 50)
            {
                dispo = Random.Range(35, 100);
            }
            else
            {
                dispo = Random.Range(0, 55);
            }
        }

        //Check if parts 3 or 4 have been picked up
        if ((!phoneParts[1].GetComponent<SpriteRenderer>().enabled) || (!phoneParts[2].GetComponent<SpriteRenderer>().enabled))
        {
            speed = (float)((Random.Range(30, 50)) / 100.0F);
            dispo = other.GetComponent<Player>().disposition.disposition;
            if (dispo >= 50)
            {
                dispo = Random.Range(0, 75);
            }
            else
            {
                dispo = Random.Range(35, 100);
            }
        }
    }
}
