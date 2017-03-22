﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHand : MonoBehaviour {

    public GameObject target;

    public Animator anim;

    public float turnRate;
    public float turnRateAcceleration;
    public float speed;

    private int LifeCycle;
    private Player p;

	// Use this for initialization
	void Start () {
        LifeCycle = 3;
        p = target.GetComponent<Player>();
        StartCoroutine(Punch());
    }

    // Update is called once per frame
    private void Update()
    {
        if (LifeCycle<=0) {
            Destroy(this.gameObject);
        }
    }
    IEnumerator Punch()
    {
        LifeCycle -= 1;
        yield return new WaitForSeconds(10);
        
        anim.SetTrigger("atk");
        
        StartCoroutine(Punch());
    }
    
    public void ReachForPlayer() {
        if (target) {
            Vector3 targetPos = target.gameObject.transform.position;
            Vector3 relativePos = targetPos - transform.position;
            Quaternion targetRot = Quaternion.LookRotation(relativePos);

            float targetRotAngle = -targetRot.eulerAngles.z;
            float currentRotAngle = transform.eulerAngles.z;

            currentRotAngle = Mathf.LerpAngle(currentRotAngle, targetRotAngle, turnRate*Time.deltaTime);

            Quaternion tiltedRot = Quaternion.Euler(0, 0, currentRotAngle);

            turnRate += turnRateAcceleration * Time.deltaTime;

            transform.rotation = tiltedRot;

            transform.Translate(new Vector3( speed * Time.deltaTime, 0f,0f));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            p.health -= 1;
        }
        if (collision.tag == "Untagged") {
            Time.timeScale = 0.3f;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        Time.timeScale = 1.0f;
        
    }
}