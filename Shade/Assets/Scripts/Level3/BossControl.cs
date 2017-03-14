using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour {

    public int HP;
    public GameObject Spike_prefab;
    public GameObject Hand1_prefab;
    public GameObject Hand2_prefab;
    public GameObject Shield;
    public List<GameObject> FirePoints;
	// Use this for initialization
	void Start () {
        HP = 20;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Fire() {
        foreach (GameObject point in FirePoints) {
            Instantiate(Spike_prefab, point.transform.position, point.transform.rotation);
        }
    }
}
