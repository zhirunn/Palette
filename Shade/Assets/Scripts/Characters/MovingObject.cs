using UnityEngine;
using System.Collections;

// From https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/moving-object-script?playlist=17150
// The abstract keyword enables you to create classes and class members that are incomplete and must be implemented in a derived class.
public abstract class MovingObject : DispositionObject
{
    // Properties
    public float moveTime = 1.0f; // Time it will take object to move, in seconds.
    public LayerMask blockingLayer; // Layer on which collision will be checked.

    [HideInInspector]
    public Vector2 lastMove; // Stores the last used vector for movement

    // Cache variables
    protected Collider2D collider2d;
    protected Rigidbody2D rb2d;
    protected float inverseMoveTime; // Used to make movement more efficient.

    protected override void Start()
    {
        collider2d = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        psr = GetComponent<ParticleSystemRenderer>();

        // Store the reciprocal so that we can use it by multiplication next time
        // More efficient approach
        inverseMoveTime = 1f / moveTime;

        // Call the start function of our base class DispositionObject.
        base.Start();
    }

    /// <summary>
    /// Moves the object in the given x and y direction. 
    /// The time factor and move time are factored by this function.
    /// </summary>
    /// <param name="xDir">x direction</param>
    /// <param name="yDir">y direction</param>
    protected void Move(float xDir, float yDir)
    {
        // Store start position to move from, based on objects current transform position.
        Vector2 start = transform.position;

        // Calculate end position based on the direction parameters passed in when calling Move.
        Vector2 end = start + new Vector2(
            xDir * Time.deltaTime * inverseMoveTime,
            yDir * Time.deltaTime * inverseMoveTime);
        lastMove = end;

        rb2d.MovePosition(end);
    }
}