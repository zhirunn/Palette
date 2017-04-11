using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2 : MonoBehaviour {
    public GameObject spawner;
    public GameObject enemyToSpawn;

    public int totalEnemy;

    public Transform[] spawnPoints;
    public GameObject passThrough;

    private Transform[] temp;

    public GameObject[] phoneParts;
    private float speed;
    private int dispo;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }

        //Defaults
        speed = (float)((Random.Range(30, 50)) / 100.0F);
        dispo = other.GetComponent<Player>().disposition.disposition;
        if (dispo >= 50)
        {
            dispo = Random.Range(50, 100);
        }
        else
        {
            dispo = Random.Range(0, 49);
        }

        for (int i = 0; i < totalEnemy; i++)
        {
            Spawn enemySpawn = spawner.GetComponent<Spawn>();
            enemySpawn.GetComponent<Spawn>().setEnemy(enemyToSpawn);

            temp = new Transform[3];

            roomMod(other);

            //Set enemy disposition
            enemySpawn.setDisposition(dispo);

            //Set enemy at random speed
            //enemySpawn.setSpeed(0.75F);
            enemySpawn.setSpeed(speed);

            //Set enemy patrol path
            int mark1 = Random.Range(0, spawnPoints.Length);
            int mark2 = Random.Range(0, spawnPoints.Length);
            int mark3 = Random.Range(0, spawnPoints.Length);
             
            //Choose patrol path
            while ((mark1 == mark2) && (mark2 == mark3))
            {
                mark1 = Random.Range(0, spawnPoints.Length);
                mark2 = Random.Range(0, spawnPoints.Length);
            }

            //Set markers
            temp[0] = spawnPoints[mark1];
            temp[1] = spawnPoints[mark2];
            temp[2] = spawnPoints[mark3];
            enemySpawn.setEnemyMarkers(temp);

            //Cycle through spawn points to spawn monsters.
            if (i >= spawnPoints.Length)
            {
                enemySpawn.GetComponent<Spawn>().setSpawnPoint(spawnPoints[i % spawnPoints.Length]);
            }
            else
            {
                enemySpawn.GetComponent<Spawn>().setSpawnPoint(spawnPoints[i]);
            }

            enemySpawn.GetComponent<Spawn>().spawn();
        }

        passThrough.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void roomMod(Collider2D other)
    {
        //Check if part 1 has been picked up
        if(!phoneParts[0].GetComponent<SpriteRenderer>().enabled)
        {
            //Picked up
            speed = (float)((Random.Range(50, 110)) / 100.0F);
            dispo = Random.Range(25, 75);
        }

        //Check if parts 3 or 4 have been picked up
        if ((!phoneParts[1].GetComponent<SpriteRenderer>().enabled) || (!phoneParts[2].GetComponent<SpriteRenderer>().enabled))
        {
            speed = (float)((Random.Range(20, 50)) / 100.0F);
            dispo = other.GetComponent<Player>().disposition.disposition;
            if (dispo >= 50)
            {
                dispo = Random.Range(0, 49);
            }
            else
            {
                dispo = Random.Range(50, 100);
            }
        }
    }
}
