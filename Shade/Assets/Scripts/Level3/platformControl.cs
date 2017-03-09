using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformControl : MonoBehaviour {

    public GameObject recyclePoint;
    public GameObject mapspawner;
    public level3generator lv3gen;

    /*
        public GameObject Explosive;
        public GameObject Shield;
        public GameObject HP_portion;
        public GameObject Empty;





        public List<Transform> item_pos;

        private List<GameObject> all_items;
        */
    //public Transform obstacle_pos1;
    public List<GameObject> all_blocks;
    // Use this for initialization
    void Start () {

        mapspawner = GameObject.Find("MapSpawner");
        lv3gen = mapspawner.GetComponent<level3generator>();
        
/*
        for (int i = 0; i < 6; i++) {
            int j = Random.Range(0, 2);
            if (j == 0)
            {
                GameObject obj = (GameObject)Instantiate(Explosive);
                all_items.Add(obj);
            }
            else if (j == 1)
            {
                GameObject obj = (GameObject)Instantiate(HP_portion);
                all_items.Add(obj);
            }
            else {
                GameObject obj = (GameObject)Instantiate(Shield);
                all_items.Add(obj);
            }
            
        }
        */
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.03f);
        if (transform.position.y >= recyclePoint.transform.position.y) {
            
            
            this.gameObject.SetActive(false);
            
            lv3gen.SpawnNextRoom();
            
        }
	}

    public void SpawnItems() {
      //  foreach (Transform pos in item_pos) {

        //}
    }
    public void SpawnBlocks() {
        int num = Random.Range(0, 6);
        GameObject block = (GameObject)Instantiate(all_blocks[num]);
        // Set Position
        // Set Parent
    }
}
