using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformControl : MonoBehaviour {

    public GameObject recyclePoint;

    public level3generator lv3gen;
	// Use this for initialization
	void Start () {
        
        lv3gen.all_tiles.Add(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.03f);
        if (transform.position.y >= recyclePoint.transform.position.y) {
            
            this.gameObject.SetActive(false);

            lv3gen.SpawnNextRoom(lv3gen.all_tiles);

        }
	}
}
