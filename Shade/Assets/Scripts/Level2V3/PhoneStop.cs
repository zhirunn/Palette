using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTwine;

public class PhoneStop : MonoBehaviour {
    public TwineTextPlayer textPlayer;
    private TwineStory story;
    public BigBossInteractable boss;
    void Start()
    {
        if(boss == null)
        {
            boss = GameObject.Find("DocEvian").GetComponent<BigBossInteractable>();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Reward")
        {
            col.transform.parent = this.transform;
            col.GetComponent<CircleCollider2D>().isTrigger = false;
            col.GetComponent<CircleCollider2D>().enabled = false;
            col.GetComponent<BoxCollider2D>().enabled = false;
            int numLeft = boss.PhonePartRetrieved();

            FadeObjectInOut fadeObjInOut = col.GetComponent<FadeObjectInOut>();
            if (fadeObjInOut != null)
            {
                fadeObjInOut.FadeOut();
            }

            if (numLeft == 0)
            {
                if (textPlayer == null)
                {
                    textPlayer = GameObject.FindObjectOfType<TwineTextPlayer>();
                }

                if (textPlayer != null)
                {
                    textPlayer.gameObject.GetComponent<Canvas>().enabled = false;
                }

                if(story == null)
                    story = GameObject.FindGameObjectWithTag("TwineStory").GetComponent<TwineStory>();


                if (textPlayer.Story.State == UnityTwine.TwineStoryState.Idle
                || textPlayer.Story.State == UnityTwine.TwineStoryState.Complete)
                {
                    textPlayer.gameObject.GetComponent<Canvas>().enabled = true;

                    //story.Begin();
                    story.Reset();
                    story.GoTo("Lastpart");

                    GameManager.Instance.PauseGame(true);
                }
            }
        }
    }
}
