using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercharacter : MonoBehaviour {

    public Animator Anime;
    public Rigidbody2D Rigid;
    public GameObject Hand;
    public bool walk;
    public bool cast;
    public bool PlayerMode = true;


    public float walkSpeed;
    public float curSpeed;
    public float maxSpeed;


    





    // Use this for initialization
    void Start () {
        walk = false;
        cast = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        curSpeed = walkSpeed;
        maxSpeed = curSpeed;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // Move senteces
        if (PlayerMode == true)
        {


            if ((horizontal != 0 || vertical != 0) && (cast == false))
            {
                walk = true;
                Rigid.velocity = new Vector2(Mathf.Lerp(0, horizontal * curSpeed, 0.8f), Mathf.Lerp(0, vertical * curSpeed, 0.8f));
            }
            else
            {
                walk = false;
            }
            Anime.SetBool("walk", walk);
            
            
        }
        HandleInput();
    }

    private void HandleInput() {
        if (Input.GetKey(KeyCode.E)) {
            cast = true;
            PlayerMode = false;
            Hand.GetComponent<SnakeMovement>().SnakeMode = true;
        }
        if (Input.GetKey(KeyCode.R)) {
            cast = false;
            PlayerMode = true;
            Hand.GetComponent<SnakeMovement>().SnakeMode = false;
        }
        
        Anime.SetBool("cast", cast);
    }
}
