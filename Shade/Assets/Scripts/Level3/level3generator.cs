using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3generator : MonoBehaviour {

    public GameObject tileprefab1;
    public GameObject tileprefab2;
    public GameObject tileprefab3;

    List<GameObject> all_tiles;    
	// Use this for initialization
	void Start () {
        all_tiles = new List<GameObject>();

        for (int i = 0; i < 3; i++) {
            GameObject obj = (GameObject) Instantiate(tileprefab1);
            obj.SetActive(false);
            all_tiles.Add(obj);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SpawnNextRoom(){


    }

    public GameObject GetUsableObject() {
        for (int i = 0; i < all_tiles.Count;i++ ) {
            if (!all_tiles[i].activeInHierarchy)
            {
                return all_tiles[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(tileprefab1);
        obj.SetActive(false);
        all_tiles.Add(obj);
        return obj;

    }
}
