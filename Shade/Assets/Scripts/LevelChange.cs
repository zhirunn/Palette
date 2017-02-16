using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {
    public String levelName;

    /*
       If a player collides with this object change level
   */
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(levelName);
    }
}
