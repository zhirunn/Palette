using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleAnimManager : MonoBehaviour {
    public Animator player;
    public Animator boss;
    public Player p;
	// Use this for initialization
	void Start () {
        boss.SetBool("battle", true);
        player.SetBool("walking",true);
        p.level3 = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
