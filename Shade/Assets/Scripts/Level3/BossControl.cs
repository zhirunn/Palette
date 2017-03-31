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
    // Use this for initialization
    private Animator anim;
	void Start () {
        anim = GetComponent<Animator>();
        HP = 20;
        StartCoroutine(FireCycle());
        

	}

    void Update() {
        if (HP <= 0 ) {
            Debug.Log("You Win!");
            Destroy(this.gameObject, 0.1f);
        }
    }

    IEnumerator FireCycle() {
        yield return new WaitForSeconds(5);
        anim.SetTrigger("SpikeATK");
        StartCoroutine(FireCycle());
    }
    IEnumerator MeleeATK() {
        yield return new WaitForSeconds(3);
        anim.SetTrigger("MeleeATK"); 
    }

    public void Fire() {
         Instantiate(Spike_prefab, FirePoint.transform.position, FirePoint.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ATKbox") {
            HP -= 1;
        }
        if (collision.tag == "")
        {
        }
    }
}
