using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTwine;

public class Level1StoryHooks : StoryHooks
{

    public GameObject doctorEvian;
    public Transform moveTo;
    public float speed = 1f;

    protected override void Start()
    {
        base.Start();
    }

    IEnumerator Negative1_Enter()
    {
        yield return Positive1_Enter();
    }

    IEnumerator Positive1_Enter()
    {
        yield return SaveDispostionWaitAndThenExit();

        StartCoroutine(MoveOverSeconds());
    }

    public IEnumerator MoveOverSeconds()
    {
        float elapsedTime = 0;
        Vector3 startingPos = doctorEvian.transform.position;
        while (elapsedTime < speed)
        {
            doctorEvian.transform.position = Vector3.Lerp(startingPos, moveTo.position, (elapsedTime / speed));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        doctorEvian.transform.position = moveTo.position;

        FadeObjectInOut fadeObj = doctorEvian.GetComponent<FadeObjectInOut>();
        if(fadeObj != null)
        {
            fadeObj.FadeOut();
        }
        else
        {
            doctorEvian.gameObject.SetActive(false);
            Debug.LogWarning("FadeObjectInOut is not attached to Doctor Evian and therefore cannot fade out! Removing the doctor instead!");
        }
    }

    IEnumerator PrettyJeweledCat_Enter()
    {
        yield return SaveDispostionWaitAndThenExit();
    }

    IEnumerator JeweledCat_Enter()
    {
        yield return SaveDispostionWaitAndThenExit();
    }

    IEnumerator CreepyMirror_Enter()
    {
        yield return SaveDispostionWaitAndThenExit();
    }

    IEnumerator SmirkingMirror_Enter()
    {
        yield return SaveDispostionWaitAndThenExit();
    }
}
