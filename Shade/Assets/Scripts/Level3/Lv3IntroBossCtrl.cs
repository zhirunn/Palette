using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv3IntroBossCtrl : MonoBehaviour {

    public Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("battle", false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
