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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }

        //TODO: Room mod

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
}
