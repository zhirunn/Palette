using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3IntroStoryHooks : StoryHooks
{
    public Animator animator;

    protected override void Start()
    {
        base.Start();
    }

    IEnumerator Enteringtheresearchlab_Enter()
    {
        yield return WaitAndThenExit();
    }

    IEnumerator AfterreadingfinalnoteIfBad_Enter()
    {
        yield return AfterreadingthefinalnoteIfGoodShion_Enter();
    }

    IEnumerator AfterreadingthefinalnoteIfGoodShion_Enter()
    {
        yield return null;
        GameManager.Instance.PauseGame(true);
    }

    IEnumerator ShionvsKazkazaGood6_Enter()
    {
        yield return ShionvsKazkazaBad5_Enter();
    }

    IEnumerator ShionvsKazkazaBad5_Enter()
    {
        yield return SaveDispostionWaitAndThenExit();
        yield return null;
        animator.SetTrigger("Transform");
    }
}
