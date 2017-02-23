using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour {

    // Use this for initialization
	IEnumerator OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "door") {
			AudioSource unlockSound = GetComponent<AudioSource>();
			unlockSound.Play();
			yield return new WaitForSeconds(0.9f);
            Destroy(col.gameObject, 0.3f);
            Destroy(this.gameObject, 0.1f);
        }
    }
}
