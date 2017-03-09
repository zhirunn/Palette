using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprints : MonoBehaviour
{
    private Vector3 lastPos = Vector3.zero;
    public float footprintSpacing = 0.1f;
    [HideInInspector]
    public List<GameObject> footprints = new List<GameObject>();
    public bool enableFootprintTracking = true;

    // Update is called once per frame
    void Update()
    {
        if (enableFootprintTracking)
        {
            if (footprints.Count == 0) AddFootprint();

            float distFromLastFootprint = (lastPos - transform.position).sqrMagnitude;

            if (distFromLastFootprint > footprintSpacing * footprintSpacing)
            {
                AddFootprint();
            }
        }
    }

    private void AddFootprint()
    {
        GameObject fp = new GameObject();
        fp.transform.position = gameObject.transform.position;
        fp.transform.rotation = gameObject.transform.rotation;
        footprints.Add(fp);

        lastPos = transform.position;
    }

    public void EnableFootprintTracking(bool enable)
    {
        enableFootprintTracking = enable;
    }
}
