using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleAnimManager : MonoBehaviour {
    public Animator player;
    public Animator boss;
	// Use this for initialization
	void Start () {
        boss.SetBool("battle", true);
        player.SetBool("walking",true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
