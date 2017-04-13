using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2V3StoryHooks : StoryHooks
{

    protected override void Start()
    {
        base.Start();
    }

    IEnumerator Level2End_Enter()
    {
        yield return SaveDispostionWaitAndThenExit(time: 0f);
    }
    
    IEnumerator Obtainingtheparts_Enter()
    {
        yield return WaitAndThenExit();
    }

    IEnumerator Obtainparts_Enter()
    {
        yield return WaitAndThenExit();
    }
    IEnumerator Lastpart_Enter()
    {
        yield return WaitAndThenExit();
    }

    IEnumerator Sealingthewarehouse_Enter()
    {
        yield return WaitAndThenExit();
    }

    IEnumerator Unsleaingthewarehouse_Enter()
    {
        yield return WaitAndThenExit();
    }

    IEnumerator Finishedtheseal_Enter()
    {
        yield return WaitAndThenExit();
    }

    IEnumerator Ifspokentoafterobtainingparts_Enter()
    {
        yield return WaitAndThenExit();
    }

    IEnumerator CalltoShionafterlevel2_Enter()
    {
        yield return WaitAndThenExit();
    }

    IEnumerator EquinoxNPCstalkingEnd_Enter()
    {
        yield return SaveDispostionWaitAndThenExit(time: 0f);
        SceneManager.LoadScene("Level3Intro");
    }

    IEnumerator DoorLocked_Enter()
    {
        yield return SaveDispostionWaitAndThenExit();
    }

}
