using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadboxboss : MonoBehaviour {

    // Use this for initialization
    public Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            player.LoseHealth(100);
        }
    }
}
