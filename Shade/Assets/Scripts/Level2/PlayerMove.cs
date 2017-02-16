using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public bool PlayerMode = true;
    public float rotationspeed;
    public float speed;
    public GameObject Hand;
	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerMode == true)
        {
            Quaternion rot = transform.rotation;
            float z = rot.eulerAngles.z;
            z -= Input.GetAxis("Horizontal") * rotationspeed * Time.deltaTime;
            rot = Quaternion.Euler(0, 0, z);
            transform.rotation = rot;

            Vector3 pos = transform.position;
            Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * speed * 2 * Time.deltaTime, 0);

            pos += rot * velocity;
            transform.position = pos;

            if (Input.GetKeyUp(KeyCode.E)) {
                PlayerMode = false;
                Hand.GetComponent<SnakeMovement>().SnakeMode = true ;
            }
            
        }
    }
    
}
