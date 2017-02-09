using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.5f;

    private Animator animator;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        
        if(vertical == 0 && horizontal == 0)
        {
            animator.enabled = false;
        }
        else
        {
            animator.enabled = true;

            if (vertical > 0)
            {
                animator.SetInteger("Direction", Direction.Up);
            }
            else if (vertical < 0)
            {
                animator.SetInteger("Direction", Direction.Down);
            }
            else if (horizontal > 0)
            {
                animator.SetInteger("Direction", Direction.Right);
            }
            else if (horizontal < 0)
            {
                animator.SetInteger("Direction", Direction.Left);
            }
        }
        
        rb2d.MovePosition(
            new Vector2(
            rb2d.position.x + horizontal * Time.deltaTime * moveSpeed, 
            rb2d.position.y + vertical * Time.deltaTime * moveSpeed)
        );
    }
}
