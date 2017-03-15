using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    public int rotOffset;
    //public Camera cam;
    // Use this for initialization
    private Animator m_anim;
    


	void Start () {
        //cam = FindObjectOfType<Camera>();
        m_anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        AimDirection();
        HandleInput();
	}
    public void AimDirection()
    {
        //  Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //  Vector3 difference = Input.mousePosition - transform.position;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = pos - transform.position;
        direction.Normalize();

        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotOffset);
        
    }
    private void HandleInput() {
        if (Input.GetKeyDown(KeyCode.L)) {
            Time.timeScale = 0.03f;
        }
        if (Input.GetKeyUp(KeyCode.L)) {
            m_anim.SetTrigger("Fire");
            Time.timeScale = 1f;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
}
