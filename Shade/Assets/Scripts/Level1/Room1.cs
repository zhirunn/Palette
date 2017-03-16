using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : MonoBehaviour {
    public GameObject spawner;
    public GameObject enemyToSpawn;

    public int totalEnemy;

    public Transform[] spawnPoints;
    public GameObject passThrough;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }

        //TODO: Room mod

        for (int i = 0; i < totalEnemy; i++)
        {
            Spawn enemySpawn = spawner.GetComponent<Spawn>();

            enemySpawn.setEnemyMarkers(spawnPoints);
            enemySpawn.GetComponent<Spawn>().setEnemy(enemyToSpawn);

            if (i < spawnPoints.Length)
            {
                print(spawnPoints.Length);
                enemySpawn.GetComponent<Spawn>().setSpawnPoint(spawnPoints[i]);
            }
            enemySpawn.GetComponent<Spawn>().spawn();
        }

        passThrough.GetComponent<BoxCollider2D>().enabled = false;

        this.GetComponent<BoxCollider2D>().enabled = false;
        
    }
}
