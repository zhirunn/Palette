using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHand : MonoBehaviour {

    public GameObject target;

    public float turnRate;
    public float turnRateAcceleration;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ReachForPlayer();
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
}
