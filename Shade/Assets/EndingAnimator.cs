using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingAnimator : MonoBehaviour {
    public Animator Player;
    public Animator Boss;
	// Use this for initialization
	void Start () {
        Boss.SetBool("Battle", false);
        Boss.SetTrigger("Death");
        Boss.SetBool("dead", true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
