using UnityEngine;
using System.Collections;

// From https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/moving-object-script?playlist=17150
// The abstract keyword enables you to create classes and class members that are incomplete and must be implemented in a derived class.
public abstract class MovingObject : MonoBehaviour
{
    // Properties
    public float moveTime = 1.0f; // Time it will take object to move, in seconds.
    public LayerMask blockingLayer; // Layer on which collision will be checked.
    [Range(0, 100)]
    public float health = 100.0f;

    [SerializeField]
    public Disposition disposition;

    // Cache variables
    protected Collider2D collider2d;
    protected Rigidbody2D rb2d;
    protected ParticleSystemRenderer psr;
    protected float inverseMoveTime; // Used to make movement more efficient.

    protected virtual void OnDispositionChange() { }

    protected virtual void Start()
    {
        collider2d = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        psr = GetComponent<ParticleSystemRenderer>();

        // Store the reciprocal so that we can use it by multiplication next time
        // More efficient approach
        inverseMoveTime = 1f / moveTime;

        if (psr != null)
        {
            UpdateDispositionColor();
            psr.enabled = false;
        }
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

        rb2d.MovePosition(end);
    }

    /// <summary>
    /// Enable or disable the disposition effect.
    /// </summary>
    /// <param name="enable"></param>
    public void ToggleDisposition(bool enable)
    {
        psr.enabled = enable;
    }

    private void UpdateDispositionColor()
    {
        OnDispositionChange();
        if (psr != null)
        {
            psr.material.EnableKeyword("_EMISSION");
            psr.material.SetColor("_Albedo", Color.black);
            psr.material.SetColor("_EmissionColor", disposition.getColor());
            psr.material.color = disposition.getColor();
        }
    }

    // Update the color when changed in the Unity editor
    void OnValidate()
    {
        UpdateDispositionColor();
    }
}