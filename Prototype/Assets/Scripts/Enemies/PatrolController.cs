using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Handles the movement of an enemy patrolling waypoints.
/// </summary>
public class PatrolController : MonoBehaviour
{
    // The locations of the path-markers
    public Transform[] markers; 
    public float speed = 5.0f;
    public float rotateSpeed = 10.0f;

    private int markerIndex = 0;
    private Rigidbody2D rb2d;

    /// <summary>
    /// Calculates the Euclidean distance between two vector positions.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns>The squared length between the two vectors.</returns>
    private float getDistance(Transform x, Transform y)
    {
        return (x.transform.position - transform.position).sqrMagnitude;
    }

    // Use this for initialization
    void Start()
    {
        // Attempt to find the closest marker
        List<Transform> orderedMarkers = markers.OrderBy(
            x => getDistance(x, transform))
            .ToList<Transform>();

        for(int i=0; i<markers.Length; ++i)
        {
            Transform m = markers[i];
            if(m == orderedMarkers[0])
            {
                markerIndex = i;
                break;
            }
        }

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform target = markers[markerIndex];

        // Determine direction and perform rotation
        //
        // Idea from asafsitner and robertbu
        // http://answers.unity3d.com/users/12068/asafsitner.html
        // http://answers.unity3d.com/users/16320/robertbu.html
        // Source:
        // http://answers.unity3d.com/answers/254209/view.html
        // http://answers.unity3d.com/answers/651344/view.html
        Vector2 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            lookRotation,
            Time.deltaTime * rotateSpeed);

        // Debug.Log("Direction and rotation set to: " + direction + " : " + lookRotation);

        // Move the enemy
        Vector2 vel = new Vector2(
            transform.position.x + speed * Time.deltaTime * direction.x, 
            transform.position.y + speed * Time.deltaTime * direction.y);
        rb2d.MovePosition(vel);

        // Debug.Log(getDistance(target, transform) + " units to " + target.name);
        if (getDistance(target, transform) < 5.0f)
        {
            markerIndex = (markerIndex + 1) % markers.Length;
            target = markers[markerIndex];
            // Debug.Log(String.Format("New target: {0} with distance of {1}.", 
            //     target.name, getDistance(target, transform)));
        }
    }
}
