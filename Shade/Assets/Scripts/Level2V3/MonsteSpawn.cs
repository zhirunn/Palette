using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsteSpawn : MonoBehaviour {

    public GameObject spawner;
    public GameObject enemyToSpawn;
    public int totalEnemy;
    public Transform[] spawnPoints;

    private Transform[] temp;
    private float speed;
    private int dispo;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != "HAND") { return; }

        //Defaults
        speed = (float)((Random.Range(50, 90)) / 100.0F);
        dispo = Random.Range(0, 50);

        for (int i = 0; i < totalEnemy; i++)
        {
            Spawn enemySpawn = spawner.GetComponent<Spawn>();
            enemySpawn.GetComponent<Spawn>().setEnemy(enemyToSpawn);

            temp = new Transform[3];

            //Set enemy disposition
            enemySpawn.setDisposition(dispo);

            //Set enemy at random speed
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

        this.GetComponent<CircleCollider2D>().isTrigger = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
    }
}
