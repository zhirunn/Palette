using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour {

    public int HP;
    public GameObject Spike_prefab;
    public GameObject Hand1_prefab;
    public GameObject Hand2_prefab;
    public GameObject Shield;
    public List<GameObject> FirePoints;
	// Use this for initialization
	void Start () {
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
        Fire();
        StartCoroutine(FireCycle());
    }
    public void Fire() {
        foreach (GameObject point in FirePoints) {
            Instantiate(Spike_prefab, point.transform.position, point.transform.rotation);
        }
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
