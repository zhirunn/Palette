using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispositionController : MonoBehaviour {
    [Range(0, 100)]
    [SerializeField]
    private int _disposition;
    public int disposition
    {
        get { return _disposition;  }
        set
        {
            _disposition = value;
            
            if(psr != null)
            {
                Color color = DispositionHelper.getColor(value);
                psr.material.SetColor("_EmissionColor", color);
            }
        }
    }

    private ParticleSystemRenderer psr;

	// Use this for initialization
	void Start () {
        psr = GetComponent<ParticleSystemRenderer>();
        disposition = _disposition;
        // psr.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
    }

    // Update the color when changed in the Unity editor
    void OnValidate()
    {
        disposition = _disposition;
    }
}
