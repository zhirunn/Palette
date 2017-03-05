using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Handles the movement of an enemy patrolling waypoints.
/// </summary>
public class EnemyPatrol : Enemy
{
    // The locations of the path-markers
    public Transform[] markers;
    public float rotateSpeed = 3.0f;
    public float distanceToMarker = 1.0f;
    private GameObject footprints;

    private int markerIndex = 0;

    ////////////////////////////////////////
    // A star path finding vars

    private GameObject player;

    private Path path = null;

    // The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 1.0f;
    // The waypoint we are currently moving towards
    private int currentWaypoint = 0;
    // How often to recalculate the path (in seconds)
    public float repathRate = 0.25f;
    private float lastRepath = -9999;
    public float giveUpTime = 1.5f;
    private float lastGiveUpTime = 1.5f;

    private Seeker seeker;

    ////////////////////////////////////////


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
    protected override void Start()
    {
        base.Start();

        player = GameObject.FindGameObjectWithTag("Player");
        seeker = GetComponent<Seeker>();

        // Attempt to find the closest marker
        List<Transform> orderedMarkers = markers.OrderBy(
            x => getDistance(x, transform))
            .ToList<Transform>();

        for (int i = 0; i < markers.Length; ++i)
        {
            Transform m = markers[i];
            if (m == orderedMarkers[0])
            {
                markerIndex = i;
                break;
            }
        }

        lastGiveUpTime = giveUpTime;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = getDistance(player.transform, transform);

        // I see the player! I'm not going to give up!
        if (distanceToPlayer < 25.0f)
        {
            lastGiveUpTime = 0;
        }
        
        // Don't give up quite yet...
        if (lastGiveUpTime < giveUpTime)
        {
            lastGiveUpTime += Time.deltaTime;

            if (Time.time - lastRepath > repathRate && seeker.IsDone())
            {
                lastRepath = Time.time + UnityEngine.Random.value * repathRate * 0.5f;
                seeker.StartPath(transform.position, player.transform.position, OnPathComplete);
            }
        }
        else // I give up!
        {
            path = null;
        }

        if (path != null)
        {
            if (currentWaypoint > path.vectorPath.Count)
            {
                path = null;
                return;
            }

            if (currentWaypoint == path.vectorPath.Count)
            {
                // Debug.Log("End Of Path Reached");
                currentWaypoint++;
                return;
            }

            // Direction to the next waypoint
            Vector2 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
            Move(dir.x, dir.y);

            // The commented line is equivalent to the one below, but the one that is used
            // is slightly faster since it does not have to calculate a square root
            // if (Vector2.Distance (transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
            if (currentWaypoint < path.vectorPath.Count)
            {
                if ((transform.position - path.vectorPath[currentWaypoint]).sqrMagnitude < distanceToMarker * distanceToMarker)
                {
                    currentWaypoint++;
                }
            }
        }
        else
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
            Move(direction.x, direction.y);

            // Debug.Log(getDistance(target, transform) + " units to " + target.name);
            if (getDistance(target, transform) < distanceToMarker)
            {
                markerIndex = (markerIndex + 1) % markers.Length;
                target = markers[markerIndex];
                // Debug.Log(String.Format("New target: {0} with distance of {1}.", 
                //     target.name, getDistance(target, transform)));
            }
        }
    }

    public void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            // Debug.Log("Found the next path to the player!");
            path = p;
            // Reset the waypoint counter so that we start to move towards the first point in the path
            currentWaypoint = 0;
        }
        else
        {
            Debug.Log("There was an error when calculating the path to the player!");
        }
    }

    private void footprintGeneration()
    {
        
    }

    public void OnDisable()
    {
        seeker.pathCallback -= OnPathComplete;
    }

}
