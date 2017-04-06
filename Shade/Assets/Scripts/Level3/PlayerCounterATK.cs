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
        if (Input.GetKeyDown(KeyCode.F)) {

            foreach (GameObject item in Spikes)
            {
                if (item)
                {
                    item.GetComponent<spikeControl>().speed = 0f;
                    Time.timeScale = 0.1f;
                    
                }
                m_anim.SetTrigger("Swipe");
            }
        }
        if (Input.GetKeyUp(KeyCode.F)) {
            Time.timeScale = 1f;
            foreach (GameObject item in Spikes){
                if (item)
                {
                    item.transform.Rotate(0, 0, 180f);
                    spikeControl ctrl = item.GetComponent<spikeControl>();
                    ctrl.speed = 5f;
                    ctrl.friendly_fire = true;
                }
            }
            Spikes.Clear();
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
