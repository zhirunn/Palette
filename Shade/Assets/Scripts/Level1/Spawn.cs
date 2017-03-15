using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    private Transform spawnPoint;
    private Transform[] enemyMarkers;
    private GameObject enemyToSpawn;
    private GameObject enemy;

    public void spawn()
    {
        enemy = Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
        enemy.GetComponent<EnemyPatrol>().markers = enemyMarkers;
    }

    public void setSpawnPoint(Transform newSpawnPoint)
    {
        this.spawnPoint = newSpawnPoint;
    }

    public void setEnemyMarkers(Transform[] newEnemyMarkers)
    {
        this.enemyMarkers = newEnemyMarkers;
    }

    public void setEnemy(GameObject newEnemy)
    {
        this.enemyToSpawn = newEnemy;
    }
}
