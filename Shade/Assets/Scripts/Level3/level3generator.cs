﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3generator : MonoBehaviour {

    public GameObject tileprefab1;
    public GameObject tileprefab2;
    public GameObject tileprefab3;

    public Transform SpawnPoint;

   
    public List<GameObject> All_tiles;    
	// Use this for initialization
	void Start () {
        All_tiles = new List<GameObject>();

        // Create All the tiles prefab
        GameObject obj = (GameObject)Instantiate(tileprefab1);
        obj.SetActive(false);
        All_tiles.Add(obj);

        GameObject obj4 = (GameObject)Instantiate(tileprefab2);
        obj4.SetActive(false);
        All_tiles.Add(obj4);

        for (int i = 0; i < 3; i++) {
            GameObject obj3 = (GameObject)Instantiate(tileprefab3);
            obj3.SetActive(false);
            All_tiles.Add(obj3);
        }
    }
	
    public void SpawnNextRoom(){
        GameObject obj = (GameObject) GetUsableObject();
        
        obj.transform.position = SpawnPoint.position;
        obj.transform.rotation = SpawnPoint.rotation;
        obj.GetComponent<platformControl>().SpawnItems();
        obj.GetComponent<platformControl>().SpawnBlocks();
        obj.SetActive(true);

    }

    public GameObject GetUsableObject() {
        Debug.Log(All_tiles.Count);
        for (int i = 0; i < All_tiles.Count;i++ ) {
            
            if (!All_tiles[i].activeInHierarchy)
            {
                Debug.Log("I found one");
                return All_tiles[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(tileprefab1);
        obj.SetActive(false);
        All_tiles.Add(obj);
        Debug.Log("I created one");
        return obj;
    }
    

}
