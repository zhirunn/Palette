using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTwine;

public class Level1StoryHooks : MonoBehaviour {

    public TwineTextPlayer textPlayer;
    private Canvas textPlayerCanvas;
    private TwineStory story;

    void Start()
    {
        if (textPlayer == null)
        {
            textPlayer = GameObject.FindObjectOfType<TwineTextPlayer>();
        }

        textPlayerCanvas = textPlayer.gameObject.GetComponent<Canvas>();
        story = textPlayer.Story;
    }

    IEnumerator Negative1_Enter()
    {
        yield return Positive1_Enter();
    }

    IEnumerator Positive1_Enter()
    {
        yield return null; // idle after one frame

        //TwineTextPlayer textPlayer = GameObject.FindObjectOfType<TwineTextPlayer>();
        GameManager.Instance.playerDisposition.disposition = (int) textPlayer.Story["disposition"];
        yield return new WaitForSeconds(3f);

        // Can't used the locally cached reference
        GameObject.FindObjectOfType<TwineTextPlayer>().GetComponent<Canvas>().enabled = false;
    }
}
