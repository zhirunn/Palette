using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameCredit : MonoBehaviour {
    public Animator monster;
    public Animator player;
    public Animator boss;
    // Use this for initialization

    private void Start()
    {
        StartCoroutine(end());
    }
    IEnumerator end()
    {
        yield return new WaitForSeconds(50f);
        SceneManager.LoadScene("Level0");
    }


    public void Matk() {
        monster.SetTrigger("atk");
    }
    public void BossTransform() {
        boss.SetTrigger("Transform");
    }

}
