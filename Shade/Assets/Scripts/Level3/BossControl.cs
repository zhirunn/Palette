using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour {

    public int HP;
    public List<GameObject> Spikes_prefab;
    public GameObject Hand1_prefab;
    public GameObject Hand2_prefab;
	// Use this for initialization
	void Start () {
        HP = 20;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
