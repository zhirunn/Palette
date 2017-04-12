using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTwine;

public class StoryEvent : MonoBehaviour
{
    public TwineTextPlayer textPlayer;
    public bool happensOnce = true;

    public string Passage;
    private bool Completed = false;

    private TwineStory story;

    void Start()
    {
        if (textPlayer == null)
        {
            textPlayer = GameObject.FindObjectOfType<TwineTextPlayer>();
        }

        if (textPlayer != null)
        {
            textPlayer.gameObject.GetComponent<Canvas>().enabled = false;
        }

        story = GameObject.FindGameObjectWithTag("TwineStory").GetComponent<TwineStory>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        bool isPassageOccurringMoreThanOnce = !happensOnce;
        bool isPassageOccuringOnceButHasNotHappenedYet = happensOnce && !Completed;

        if (player != null && (isPassageOccurringMoreThanOnce || isPassageOccuringOnceButHasNotHappenedYet))
        {
            if (textPlayer.Story.State == UnityTwine.TwineStoryState.Idle
                || textPlayer.Story.State == UnityTwine.TwineStoryState.Complete)
            {
                textPlayer.gameObject.GetComponent<Canvas>().enabled = true;

                //story.Begin();
                story.Reset();
                story.GoTo(Passage);

                Completed = true;

                GameManager.Instance.PauseGame(true);
            } else if (textPlayer.Story.State == UnityTwine.TwineStoryState.Playing)
            {
                textPlayer.Story.Pause();
                textPlayer.gameObject.GetComponent<Canvas>().enabled = false;

                GameManager.Instance.PauseGame(false);
            }
        }
    }

}

