/*
    Player Movement for Prototype

    Controls, and defines player movement

    William Thoang
    01-30-2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    //Variables
    private Rigidbody2D rb2d;
    private float maxSpeed;
    public float speed;

    //Initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        maxSpeed = 10f;
    }
    /*
        Deals with player movement
    */
    void FixedUpdate()
    {
        //Gets input from keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVetical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2 (moveHorizontal, moveVetical);

        //Modifies and limits max speed 
        if (rb2d.velocity.magnitude > maxSpeed) {
            rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
        } else {
            rb2d.AddForce(movement * speed);
        }
    }
}
