using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeControl : MonoBehaviour {
    public float speed;
    public PlayerCounterATK counter;
    public bool friendly_fire;
	// Use this for initialization
	void Start () {
        friendly_fire = false;
        speed = 3f;
        Destroy(this.gameObject ,4f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -Time.deltaTime * speed * GameManager.Instance.gameSpeed, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag == "BOSS") {
            if (friendly_fire == true)
            {
                collision.GetComponent<BossControl>().HP -= 1;
                // Destroy(this.gameObject, 1f);
                Destroy(this.gameObject, 0.1f);
            }
                
                // Explode
            
        }
        
        if (collision.tag == "ATKbox") {
            Destroy(this.gameObject, 0.1f);

        }
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().LoseHealth(10);

            Destroy(this.gameObject, 0.1f);

        }
    }
}
