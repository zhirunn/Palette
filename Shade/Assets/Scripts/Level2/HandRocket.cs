using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRocket : MonoBehaviour {


    public int rotOffset;
    public GameObject Hand_front;
    public GameObject Hand_back;
    public GameObject Hand_Left;
    public GameObject Hand_Right;

    //private SkinnedMeshRenderer front_hand;
  //  private SkinnedMeshRenderer back_hand;
   // private SkinnedMeshRenderer left_hand;
 //   private SkinnedMeshRenderer right_hand;

    // Use this for initialization
    void Start () {
     //   front_hand = Hand_front.GetComponent<SkinnedMeshRenderer>();
    //    back_hand = Hand_back.GetComponent<SkinnedMeshRenderer>();
    //    left_hand = Hand_Left.GetComponent<SkinnedMeshRenderer>();
    //    right_hand = Hand_Right.GetComponent<SkinnedMeshRenderer>();
		// Hand = Find("HarpoonHand")
        // Hand.setActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        //HandleInput();
        AimDirection();
    }

    void HandleInput() {
        
    }
    public void AimDirection()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotOffset);
    }
}
