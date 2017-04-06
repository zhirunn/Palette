using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHand2 : MonoBehaviour {

    public int HP;
    public Animator anim;
    public Player player;
    public Animator p_anim;
    private int Real_HP;
    private AudioSource audio1;
	// Use this for initialization
	void Start () {
        audio1 = GetComponent<AudioSource>();
        HP = 1;
        Real_HP = 3;
        anim = GetComponent<Animator>();
        StartCoroutine(ATK());
	}
    private void Update()
    {
        if (HP <= 0) {
            anim.SetTrigger("Reset");
            HP = 1;
            Real_HP -= 1;
        }
        if (Real_HP <= 0) {
            Destroy(this.gameObject, 0.1f);
        }
    }
    // Update is called once per frame
    IEnumerator ATK() {
        yield return new WaitForSeconds(15);
        anim.SetTrigger("ATK");
        StartCoroutine(ATK());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ATKbox") {
            HP -= 1;
            audio1.Play();
        }
        if (collision.tag == "Player") {
            player.LoseHealth(5);
            p_anim.SetTrigger("hit");
        }
    }
    
}
