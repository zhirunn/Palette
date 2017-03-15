using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : MonoBehaviour {
    public GameObject spawner;
    //public Transform[] spawnPoints;
    public GameObject enemyToSpawn;
    public Transform[] enemyMarkers;

    public int numEnemy;

    // Use this for initialization
    void Start () {
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") { return; }

        //TODO: Room mod

        spawner.GetComponent<Spawn>().enemyMarkers = this.enemyMarkers;
        spawner.GetComponent<Spawn>().spawnPoint = this.enemyMarkers[2];
        spawner.GetComponent<Spawn>().enemyToSpawn = this.enemyToSpawn;
    }
}
