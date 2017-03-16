﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHand2 : MonoBehaviour {

    public int HP;
    public Animator anim;
	// Use this for initialization
	void Start () {
        HP = 1;
        anim = GetComponent<Animator>();
        StartCoroutine(ATK());
	}
    private void Update()
    {
        if (HP <= 0) {
            anim.SetTrigger("Reset");
            HP = 1;
        }
    }
    // Update is called once per frame
    IEnumerator ATK() {
        yield return new WaitForSeconds(15);
        anim.SetTrigger("ATK");
        StartCoroutine(ATK());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ATKbox") {
            HP -= 1;
        }
    }
    
}
