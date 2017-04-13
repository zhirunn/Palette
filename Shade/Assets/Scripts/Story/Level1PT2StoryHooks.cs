using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTwine;

public class Level1PT2StoryHooks : StoryHooks
{

    protected override void Start()
    {
        base.Start();
    }

    IEnumerator KazkazarequestEnd_Enter()
    {
        yield return SaveDispostionWaitAndThenExit(time: 0f);
        SceneManager.LoadScene("Level2V3");
    }

    IEnumerator Holophonebatteryrecoveryfirst_Enter()
    {
        yield return SaveDispostionWaitAndThenExit();
    }

    IEnumerator Holophonerecoverysecond_Enter()
    {
        yield return SaveDispostionWaitAndThenExit();
    }

    IEnumerator Holophonebatteryrecoverysecond_Enter()
    {
        yield return SaveDispostionWaitAndThenExit();
    }

    IEnumerator Holophonerecoveryfirst_Enter()
    {
        yield return SaveDispostionWaitAndThenExit();
    }

}
