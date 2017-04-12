using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2V3StoryHooks : StoryHooks
{

    protected override void Start()
    {
        base.Start();

        GameObject bossMonster = GameObject.Find("BossMonster");
        if (bossMonster != null)
        {
            Interactable inter = bossMonster.GetComponent<Interactable>();
            if (GameManager.Instance.playerDisposition.getColor() == Disposition.POSITIVE)
            {
                inter.Passage = "AfterreadingthefinalnoteIfGoodShion";
            }
            else
            {
                inter.Passage = "AfterreadingfinalnoteIfBad";
            }
        }
        else
        {
            Debug.Log("Could not find GameObject with name BossMonster!");
        }
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

}
