using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTwine;

public class StoryHooks : MonoBehaviour
{

    public TwineTextPlayer textPlayer;
    protected Canvas textPlayerCanvas;
    protected TwineStory story;

    protected virtual void Start()
    {
        if (textPlayer == null)
        {
            textPlayer = GameObject.FindObjectOfType<TwineTextPlayer>();
        }

        textPlayerCanvas = textPlayer.gameObject.GetComponent<Canvas>();
        story = textPlayer.Story;
    }

    protected IEnumerator SaveDispostionWaitAndThenExit()
    {
        yield return null; // idle after one frame

        //TwineTextPlayer textPlayer = GameObject.FindObjectOfType<TwineTextPlayer>();
        GameManager.Instance.playerDisposition.disposition += (int)textPlayer.Story["disposition"];

        GameManager.Instance.PauseGame(true);

        yield return new WaitForSeconds(3f);

        // Can't used the locally cached reference
        GameObject.FindObjectOfType<TwineTextPlayer>().GetComponent<Canvas>().enabled = false;

        GameManager.Instance.PauseGame(false);
    }

    protected IEnumerator WaitAndThenExit()
    {
        yield return null; // idle after one frame

        GameManager.Instance.PauseGame(true);

        yield return new WaitForSeconds(3f);

        // Can't used the locally cached reference
        GameObject.FindObjectOfType<TwineTextPlayer>().GetComponent<Canvas>().enabled = false;

        GameManager.Instance.PauseGame(false);
    }

}
