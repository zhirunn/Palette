using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public Transform spawnPoint;
    public GameObject enemyToSpawn;
    public Transform[] enemyMarkers;

    private GameObject enemy;

	// Use this for initialization
	void Start () {
        enemy = Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
        enemy.GetComponent<EnemyPatrol>().markers = enemyMarkers;
    }
}
