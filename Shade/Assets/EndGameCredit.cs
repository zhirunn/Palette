using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameCredit : MonoBehaviour {
    public Animator monster;
    public Animator player;
    public Animator boss;
    // Use this for initialization
    public void Matk() {
        monster.SetTrigger("atk");
    }
    public void BossTransform() {
        boss.SetTrigger("Transform");
    }

    public void EndGame() {
        
        SceneManager.LoadScene("Level0");
    }
}
