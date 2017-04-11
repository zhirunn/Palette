using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3IntroStoryHooks : StoryHooks
{
    public Animator animator;

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

    IEnumerator ShionvsKazkazaGood6_Enter()
    {
        yield return ShionvsKazkazaBad5_Enter();
    }

    IEnumerator ShionvsKazkazaBad5_Enter()
    {
        yield return SaveDispostionWaitAndThenExit();
        yield return null;
        animator.SetTrigger("Transform");
        yield return new WaitForSeconds(7.0f);

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
