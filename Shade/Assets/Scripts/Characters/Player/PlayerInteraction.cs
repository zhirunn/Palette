using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public TwineTextPlayer textPlayer;

    private Interactable interactable = null;
    private GameObject iteractableGameObject = null;

    private bool _showText = false;
    //bool _CanTalk = false;

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
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(interactable == null)
        {
            Interactable iter = other.gameObject.GetComponent<Interactable>();
            if (iter != null)
            {
                iteractableGameObject = other.gameObject;
                interactable = iter;
            }
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
        if (interactPressed && interactable != null && interactable.Completed == false)
        {
            _showText = true;

            if (textPlayer.Story.State == UnityTwine.TwineStoryState.Idle
                || textPlayer.Story.State == UnityTwine.TwineStoryState.Complete)
            {
                textPlayer.gameObject.GetComponent<Canvas>().enabled = true;

                //GameManager.Instance.Story.Begin();
                GameManager.Instance.Story.Reset();
                GameManager.Instance.Story.GoTo(interactable.Passage);
                interactable.Completed = true;
            }
        }

        if (_showText == false)
        {
            if (textPlayer.Story.State == UnityTwine.TwineStoryState.Playing)
            {
                textPlayer.Story.Pause();
                textPlayer.gameObject.GetComponent<Canvas>().enabled = false;
            }
        }
    }

}

