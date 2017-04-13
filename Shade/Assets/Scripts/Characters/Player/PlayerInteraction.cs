using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTwine;

public class PlayerInteraction : MonoBehaviour
{
    public TwineTextPlayer textPlayer;

    private Interactable interactable = null;
    private GameObject iteractableGameObject = null;

    private bool _showText = false;
    //bool _CanTalk = false;

    TwineStory story;

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
        Interactable iter = other.gameObject.GetComponent<Interactable>();
        if (iter != null)
        {
            iteractableGameObject = other.gameObject;
            interactable = iter;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // If we had previously encountered an interactable object
        // AND if the other object that just exit is the same object that we found was interactable
        // THEN disable the interaction
        //
        // This scenario solves the edge case of this method being called on non-interactable but collidable game objects
        if (interactable != null && other.gameObject == iteractableGameObject)
        {
            interactable = null;
            iteractableGameObject = null;
            _showText = false;
        }
    }

    void Update()
    {
        bool interactPressed = Input.GetButtonDown("Interact");

        // TODO Change animation keyframe of the player while talking?
        if (interactPressed && interactable != null && (interactable.Completed == false || interactable.Repeats))
        {
            _showText = true;

            if (textPlayer.Story.State == UnityTwine.TwineStoryState.Idle
                || textPlayer.Story.State == UnityTwine.TwineStoryState.Complete)
            {
                textPlayer.gameObject.GetComponent<Canvas>().enabled = true;

                //story.Begin();
                story.Reset();
                story.GoTo(interactable.Passage);

                interactable.Completed = true;
            }

            GameManager.Instance.PauseGame(true);
        }

        if (_showText == false)
        {
            if (textPlayer.Story.State == UnityTwine.TwineStoryState.Playing)
            {
                textPlayer.Story.Pause();
                textPlayer.gameObject.GetComponent<Canvas>().enabled = false;

                GameManager.Instance.PauseGame(false);
            }
        }
    }

}

