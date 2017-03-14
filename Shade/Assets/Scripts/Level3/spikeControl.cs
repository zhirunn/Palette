using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeControl : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        speed = 3f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -Time.deltaTime * speed, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BOSS") {
            collision.GetComponent<BossControl>().HP -= 1;
            Destroy(this.gameObject, 1f);
            // Explode
        }
        if (collision.tag == "Player") {
            collision.GetComponent<Player>().health -= 20f;
            Destroy(this.gameObject, 1f);
            // Explode
        }
        if (collision.tag == "ATKbox") {
            Destroy(this.gameObject, 1f);
        }
        
    }
}
