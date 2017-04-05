using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour {

    public int HP;
    public GameObject Spike_prefab;
    public GameObject FirePoint;
    public GameObject player;
    // Use this for initialization
    private Animator anim;
    private float distance;
    private bool dead;
    private AudioSource source;
	void Start () {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        HP = 20;
        //
        dead = false;
        StartCoroutine(Attack());
	}


    void Update() {
        distance = transform.position.y - player.transform.position.y;
        if (HP <= 0 ) {
            Debug.Log("You Win!");
            
            if (dead == false) {
                anim.SetTrigger("Death");
                anim.SetTrigger("Death");
                anim.SetTrigger("Death");
                anim.SetBool("dead", true);
                dead = true;
                StartCoroutine(ShiftToNext());
            }
            
            //Destroy(this.gameObject, 0.1f);
            //
        }

    }
    IEnumerator Attack() {
        yield return new WaitForSeconds(1);
        if (distance >= 3)
        {
            if (!dead)
            {
                anim.SetTrigger("SpikeATK");
                yield return new WaitForSeconds(3);
            }
        }
        else {
            if (!dead)
            {
                anim.SetTrigger("MeleeATK");
                yield return new WaitForSeconds(6);
            }
        }
        StartCoroutine(Attack());

    }
    IEnumerator ShiftToNext() {
        yield return new WaitForSeconds(5);
        Application.LoadLevel("BossPlayerSettlement");
    }

    public void Fire() {
         Instantiate(Spike_prefab, FirePoint.transform.position, FirePoint.transform.rotation);
    }
    public void Shout() {
        source.Play();
    }
    public void attacking() {
        anim.SetBool("Attacking", true);
    }
    public void notatking() {
        anim.SetBool("Attacking", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ATKbox") {
            HP -= 1;
            anim.SetTrigger("hit");
        }
        
    }
}
