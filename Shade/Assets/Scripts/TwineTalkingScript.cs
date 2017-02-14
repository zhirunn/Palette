using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwineTalkingScript : MonoBehaviour
{
    public TwineTextPlayer textPlayer;

    private Interactable iteractable = null;
    private GameObject iteractableGameObject = null;

    private bool _showText = false;
    //bool _CanTalk = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Interactable iter = other.gameObject.GetComponent<Interactable>();
        if (iter != null)
        {
            iteractableGameObject = other.gameObject;
            iteractable = iter;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // If we had previously encountered an interactable object
        // AND if the other object that just exit is the same object that we found was interactable
        // THEN disable the interaction
        //
        // This scenario solves the edge case of this method being called on non-interactable but collidable game objects
        if (iteractable != null && other.gameObject == iteractableGameObject)
        {
            iteractable = null;
            iteractableGameObject = null;
            _showText = false;
        }
    }

    void Update()
    {
        bool iteractPressed = Input.GetButtonDown("Interact");

        // TODO Change animation keyframe of the player while talking?
        if (iteractPressed && iteractable != null)
        {
            _showText = true;
            textPlayer.gameObject.SetActive(true);
            //textPlayer.gameObject.GetComponent<TwineTextPlayer>().StartStory = true;
        }

        if (_showText == false)
        {
            textPlayer.gameObject.SetActive(false);
        }
    }
}

