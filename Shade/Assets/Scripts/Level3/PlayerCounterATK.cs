using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounterATK : MonoBehaviour {


    public List<GameObject> Spikes;
    public Animator m_anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K)) {
            if (Spikes.Count > 0) {
                foreach (GameObject item in Spikes)
                {
                    item.GetComponent<spikeControl>().speed = 0f;
                }
                Time.timeScale = 0.1f;
                m_anim.SetTrigger("Swipe");
            }

        }
        if (Input.GetKeyUp(KeyCode.K)) {
            Time.timeScale = 1f;
            foreach (GameObject item in Spikes){
                item.transform.Rotate(0, 0, 180f);
                item.GetComponent<spikeControl>().speed = 5f;
            }
        }
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "spike")
        {
            Spikes.Add(col.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "spike")
        {
            Spikes.Remove(collision.gameObject);
        }
    }
}
