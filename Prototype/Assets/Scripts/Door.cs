/*
    Door Controller for Prototype

    Changes level if player touches this door

    William Thoang
    01-30-2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    /*
        If a player collides with this door, change level, otherwise do nothing
    */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("TestLevel"); //Set level here
        }
    }
}
