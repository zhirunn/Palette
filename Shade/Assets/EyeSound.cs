using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSound : MonoBehaviour {

    public AudioSource eye_audio;
	// Use this for initialization
	void Start () {
        eye_audio = GetComponent<AudioSource>();

    }

    public void Activate_Sound() {
        eye_audio.Play();
    }
}
