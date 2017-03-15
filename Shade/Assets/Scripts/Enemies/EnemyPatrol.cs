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

    private GameObject targetFound;

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

    private VisionObject visionObject;

    /// <summary>
    /// Calculates the Euclidean distance between the object's position target vector position.
    /// </summary>
    /// <param name="v"></param>
    /// <returns>The squared length between the two vectors.</returns>
    private float getDistance(Vector3 target)
    {
        return (target - transform.position).sqrMagnitude;
    }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        seeker = GetComponent<Seeker>();

        // Attempt to find the closest marker
        List<Transform> orderedMarkers = markers.OrderBy(
            x => getDistance(x.position))
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

        visionObject = GetComponentInChildren<VisionObject>();
        visionObject.NewTargetFound += HandleNewTargetFound;
    }

    void HandleNewTargetFound(object sender, EventArgs args)
    {
        targetFound = visionObject.GetClosestTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetFound != null)
        {
            // Verify that the targetFound is actually the closest target
            // Switch targets if a closer target is found
            GameObject newCloserTarget = visionObject.GetClosestTarget();
            if (newCloserTarget != targetFound && newCloserTarget != null)
            {
                DispositionObject targetFoundDisposition = newCloserTarget.GetComponent<DispositionObject>();
                if (targetFoundDisposition != null
                    && targetFoundDisposition.health > 0 && targetFoundDisposition.recharging == false)
                {
                    targetFound = newCloserTarget;
                    if (targetFound == null)
                        return;
                }

                // Debug.Log("New closer target found: " + newCloserTarget);
                targetFound = newCloserTarget;
            }

            float distanceToPlayer = getDistance(targetFound.transform.position);

            // I see the player! I'm not going to give up!
            if (visionObject.activeTargetsFound.Contains(targetFound))
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
                    seeker.StartPath(transform.position, targetFound.transform.position, OnPathComplete);
                }
            }
            else // I give up!
            {
                float distanceToRoute = getDistance(markers[markerIndex].transform.position);
                if (distanceToRoute > 3.0f)
                {
                    seeker.StartPath(transform.position, markers[markerIndex].position, OnPathComplete);
                }
                else
                {
                    path = null;
                }
            }
        }

        Vector3 target;

        if (path != null)
        {
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

            target = path.vectorPath[currentWaypoint];
        }
        else
        {
            target = markers[markerIndex].position;

            // Debug.Log(getDistance(target, transform) + " units to " + target.name);
            if (getDistance(target) < distanceToMarker)
            {
                markerIndex = (markerIndex + 1) % markers.Length;
                target = markers[markerIndex].position;
                // Debug.Log(String.Format("New target: {0} with distance of {1}.", 
                //     target.name, getDistance(target, transform)));
            }
        }

        // Determine direction and perform rotation
        //
        // Idea from asafsitner and robertbu
        // http://answers.unity3d.com/users/12068/asafsitner.html
        // http://answers.unity3d.com/users/16320/robertbu.html
        // Source:
        // http://answers.unity3d.com/answers/254209/view.html
        // http://answers.unity3d.com/answers/651344/view.html
        Vector2 direction = (target - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            lookRotation,
            Time.deltaTime * rotateSpeed);

        // Debug.Log("Direction and rotation set to: " + direction + " : " + lookRotation);

        // Move the enemy
        Move(direction.x, direction.y);
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            // Debug.Log("Found the next path to the player!");
            path = p;
            // Reset the waypoint counter so that we start to move towards the first point in the path
            currentWaypoint = 0;
        }
        else
        {
            Debug.LogError("There was an error when calculating the path to the player!");
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Distraction"
            && (transform.position - coll.gameObject.transform.position).sqrMagnitude < distanceToMarker * distanceToMarker)
        {
            DispositionObject dispositionObj = coll.gameObject.GetComponent<DispositionObject>();

            if (dispositionObj == null)
            {
                Debug.LogError(String.Format("Distraction does not have the {1} script attached!", typeof(DispositionObject).Name));
                return;
            }

            if (dispositionObj.health >= 0 && dispositionObj.recharging == false)
            {
                dispositionObj.health -= 10 * Time.deltaTime;
            }
        }
    }

    private void footprintGeneration()
    {

    }

    public void OnDisable()
    {
        seeker.pathCallback -= OnPathComplete;
        visionObject.NewTargetFound -= HandleNewTargetFound;
    }
}
