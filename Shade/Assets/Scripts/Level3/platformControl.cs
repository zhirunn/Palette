using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformControl : MonoBehaviour {

    public GameObject recyclePoint;

    public level3generator lv3gen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        move();
        if (transform.position.y >= recyclePoint.transform.position.y) {
            this.gameObject.SetActive(false);
        }
	}

    private void move() {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.03f);
    }

}
