using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class VisionObject : MonoBehaviour
{
    private Collider2D coll;
    private MovingObject movingObject;
    [HideInInspector]
    private List<GameObject> targetsFound = new List<GameObject>();

    private int layerMask;

    public event EventHandler NewTargetFound;

    private Predicate<GameObject> filterByActiveObjects = (GameObject g) =>
    {
        DispositionObject dispositionObj = g.GetComponent<DispositionObject>();
        if (dispositionObj != null
        && dispositionObj.recharging == false
        && dispositionObj.health > 0)
        {
            return true;
        }

        return false;
    };

    [HideInInspector]
    public List<GameObject> activeTargetsFound
    {
        get
        {
            return targetsFound.FindAll(filterByActiveObjects);
        }
    }

    // Start overrides the virtual Start function of the base class.
    void Start()
    {
        coll = GetComponent<Collider2D>();
        movingObject = GetComponentInParent<MovingObject>();

        int backgroundLayer = 1 << LayerMask.NameToLayer("Background");
        int propsLayer = 1 << LayerMask.NameToLayer("Props");
        int itemsLayer = 1 << LayerMask.NameToLayer("Items");

        layerMask = backgroundLayer | propsLayer | itemsLayer;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Distraction")
        {
            DispositionObject dispositionObj = coll.gameObject.GetComponent<DispositionObject>();

            if (dispositionObj == null)
                return;

            if (dispositionObj.disposition.getColor() == movingObject.disposition.getColor())
                return;

            // FOV idea from http://unity.grogansoft.com/enemies-that-can-see/
            GameObject target = coll.gameObject;

            RaycastHit2D[] hits = Physics2D.RaycastAll(
                transform.position,
                target.transform.position - transform.position,
                Vector2.Distance(transform.position, target.transform.position), layerMask);
            if (hits.Length == 0)
            {
                if (targetsFound.Contains(target) == false)
                {
                    // Debug.Log("Found a target with name " + target.name);
                    targetsFound.Add(target);
                    NewTargetFound(this, EventArgs.Empty);
                }
            }
            else
            {
                targetsFound.Remove(target);
            }
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Distraction")
        {
            targetsFound.Remove(coll.gameObject);
        }
    }

    public GameObject GetClosestTarget()
    {
        if (targetsFound.Count == 0) return null;

        targetsFound.Sort((GameObject t1, GameObject t2) =>
        {
            float dist1 = Vector2.Distance(gameObject.transform.position, t1.transform.position);
            float dist2 = Vector2.Distance(gameObject.transform.position, t2.transform.position);
            return dist1.CompareTo(dist2);
        });

        if (activeTargetsFound.Count == 0)
        {
            // Debug.Log("No targets found...");
            return null;
        }

        GameObject target = activeTargetsFound[0];

        DispositionObject targetDispositionObj = target.GetComponent<DispositionObject>();

        // Debug.Log(String.Format("Closest target of {0} targets is {1} (health: {2}).", activeTargetsFound.Count, target, targetDispositionObj.health));
        return target;
    }
}
