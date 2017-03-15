using UnityEngine;
using System.Collections;

// From https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-enemy-script?playlist=17150
public class Enemy : MovingObject
{
    public int playerDamage; // Damage amount

    private Animator animator;
    private Transform target; // Transform to attempt to move toward each turn.

    // Start overrides the virtual Start function of the base class.
    protected override void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        // Call the start function of our base class MovingObject.
        base.Start();
    }
}
