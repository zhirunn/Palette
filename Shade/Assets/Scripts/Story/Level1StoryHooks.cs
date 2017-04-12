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

    IEnumerator Negative1_Exit()
    {
        yield return Positive1_Exit();
    }

    IEnumerator Positive1_Exit()
    {
        yield return null;
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
            doctorEvian.GetComponent<CircleCollider2D>().isTrigger = true;
        }
        else
        {
            doctorEvian.gameObject.SetActive(false);
            Debug.LogWarning("FadeObjectInOut is not attached to Doctor Evian and therefore cannot fade out! Removing the doctor instead!");
        }
    }

    IEnumerator Level1End_Enter()
    {
        yield return SaveDispostionWaitAndThenExit(time:0f);
    }
}
