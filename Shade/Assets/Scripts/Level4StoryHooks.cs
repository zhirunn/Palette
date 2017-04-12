using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4StoryHooks : StoryHooks
{
    private bool Kazkazaattempt = false;
    private Interactable bossInteractable;
    private Interactable exitInteractable;

    protected override void Start()
    {
        base.Start();

        GameObject bossMonster = GameObject.Find("BossMonster");
        if (bossMonster != null)
        {
            bossInteractable = bossMonster.GetComponent<Interactable>();
            if (GameManager.Instance.playerDisposition.getColor() == Disposition.POSITIVE)
            {
                bossInteractable.Passage = "GoodShionpostBoss";
            }
            else
            {
                bossInteractable.Passage = "BadShionpostboss";
            }
        }
        else
        {
            Debug.Log("Could not find GameObject with name BossMonster!");
        }

        GameObject exit = GameObject.Find("Exit");
        if (exit != null)
        {
            exitInteractable = exit.GetComponent<Interactable>();
            if (GameManager.Instance.playerDisposition.getColor() == Disposition.POSITIVE)
            {
                exitInteractable.Passage = "EpilogueGood";
            }
            else
            {
                exitInteractable.Passage = "EpilogueBad";
            }
        }
        else
        {
            Debug.Log("Could not find GameObject with name Exit!");
        }
    }

    IEnumerator BadShionpostboss4_Enter()
    {
        yield return WaitAndThenExit();

        bossInteractable.Completed = false;
        bossInteractable.Passage = "Kazkazaattempt";

        // TODO: Spawn shadow monsters
    }

    IEnumerator GoodShionpostBoss4_Enter()
    {
        yield return WaitAndThenExit(0f);

        bossInteractable.Completed = false;
        bossInteractable.Passage = "Kazkazaattempt";

        // TODO: Show fires
    }

    IEnumerator ShionpostBossEnd_Enter()
    {
        return WaitAndThenExit(time: 0f);
    }

    IEnumerator Kazkazaattempt_Enter()
    {
        yield return WaitAndThenExit();

        bossInteractable.Completed = false;
        bossInteractable.Passage = "Getoutofthepan";
    }

    IEnumerator Getoutofthepan_Enter()
    {
        yield return WaitAndThenExit();
    }

    IEnumerator TheEnd_Enter()
    {
        yield return WaitAndThenExit(time:0f);
        SceneManager.LoadScene("credits");
//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying = false;
//#else
		
//#endif
    }
}
