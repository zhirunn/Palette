using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3IntroStoryHooks : StoryHooks
{
    public Animator animator;
    public AudioSource growlAudio;

    protected override void Start()
    {
        base.Start();

        GameObject bossMonster = GameObject.Find("BossMonster");
        if(bossMonster != null)
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

    IEnumerator FinaleIntroEnd_Enter()
    {
        yield return SaveDispostionWaitAndThenExit(time:0f);
        yield return null;
        animator.SetTrigger("Transform");

        if (growlAudio != null)
            growlAudio.Play();

        yield return new WaitForSeconds(7.0f);

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
