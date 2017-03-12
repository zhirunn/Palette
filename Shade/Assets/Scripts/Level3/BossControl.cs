using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour {

    public float HP;
    public List<GameObject> Spikes_prefab;
    public GameObject Hand1_prefab;
    public GameObject Hand2_prefab;
	// Use this for initialization
	void Start () {
        HP = 100f;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
