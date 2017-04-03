using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    private Transform spawnPoint;
    private Transform[] enemyMarkers;
    private GameObject enemyToSpawn;
    private GameObject enemy;
    private int disp = 100;
    private float speed = 1.0F;

    public void spawn()
    {
        enemy = Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
        enemy.GetComponent<EnemyPatrol>().markers = enemyMarkers;
        enemy.GetComponent<EnemyPatrol>().disposition.disposition = this.disp;
        enemy.GetComponent<EnemyPatrol>().moveTime = this.speed;
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

    public void setDisposition(int disposition)
    {
        this.disp = disposition;
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
}
