using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3 : MonoBehaviour {

    public GameObject spawner;
    public GameObject enemyToSpawn;
    public int totalEnemy;

    private Transform[] spawnPoints;
    private GameObject[] markers;

    void onStart()
    {
        markers = GameObject.FindGameObjectsWithTag("Room2Spawn");
        spawnPoints = new Transform[2];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }

        //TODO: Room mod


        for (int i = 0; i < totalEnemy; i++)
        {
            Spawn enemySpawn = spawner.GetComponent<Spawn>();

            spawnPoints.SetValue(markers[0].GetComponent<Transform>(), i);
            spawnPoints.SetValue(markers[1].GetComponent<Transform>(), i + 1);
            spawnPoints.SetValue(markers[2].GetComponent<Transform>(), i + 2);

            enemySpawn.setEnemyMarkers(spawnPoints);
            enemySpawn.GetComponent<Spawn>().setEnemy(enemyToSpawn);

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

        this.GetComponent<BoxCollider2D>().enabled = false;

    }
}
