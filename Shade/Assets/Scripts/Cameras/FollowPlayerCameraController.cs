using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script from https://unity3d.com/learn/tutorials/projects/2d-ufo-tutorial/following-player-camera
public class FollowPlayerCameraController : MonoBehaviour
{
    // Store a reference to the player game object
    private Player player;

    private SnakeMovement hand;

    /// <summary>
    /// Set to true if the scene x and y offset to the player should always be maintained; false to force the camera to center on the player.
    /// </summary>
    public bool keepOffset;

    // Private variable to store the offset distance between the player and camera
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if(player.Hand != null)
            hand = player.Hand.GetComponent<SnakeMovement>();

        if (keepOffset)
        {
            // Calculate and store the offset value by getting the distance between the player's position and camera's position.
            offset = transform.position - player.transform.position;
        }
        else
        {
            offset = Vector3.zero;
            offset.z = transform.position.z;
        }
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if(player != null)
        {
            GameObject target = player.gameObject;

            if (hand != null && (hand.SnakeMode || hand.RetractMode))
                target = hand.gameObject;

            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = target.transform.position + offset;
        }
    }
}
