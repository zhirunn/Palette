using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour {

    public int HP;
    public GameObject Spike_prefab;
    //public GameObject Hand_Left;
    //public GameObject Hand_Right;
    //public GameObject Shield;
    public GameObject FirePoint;
    public GameObject player;
    // Use this for initialization
    private Animator anim;
    private float distance;
    private bool dead;
	void Start () {
        anim = GetComponent<Animator>();
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

            }
            
            //Destroy(this.gameObject, 0.1f);
            //Application.LoadLevel("BossPlayerSettlement");
        }

    }
    IEnumerator Attack() {
        yield return new WaitForSeconds(1);
        if (distance >= 3)
        {
            anim.SetTrigger("SpikeATK");
            yield return new WaitForSeconds(3);
        }
        else {
            anim.SetTrigger("MeleeATK");
            yield return new WaitForSeconds(6);
        }
        StartCoroutine(Attack());

    }

    public void Fire() {
         Instantiate(Spike_prefab, FirePoint.transform.position, FirePoint.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ATKbox") {
            HP -= 1;
            anim.SetTrigger("hit");
        }
        if (collision.tag == "")
        {
        }
    }
}
