using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispositionObject : MonoBehaviour
{

    [Range(0, 100)]
    public float health = 100.0f;

    private float initialHealth;

    [SerializeField]
    public Disposition disposition;

    protected ParticleSystemRenderer psr;

    /// <summary>
    /// If true, then the health can recharge back to 100.
    /// </summary>
    public bool rechargeable;

    [HideInInspector]
    public bool recharging;

    public float rechargeSeconds = 10.0f;
    private float _rechargeSecondsInverse;

    protected virtual void OnDispositionChange() { }

    // Use this for initialization
    protected virtual void Start()
    {
        psr = GetComponent<ParticleSystemRenderer>();

        if (psr != null)
        {
            UpdateDispositionColor();
            psr.enabled = false;
        }

        // Register this object with our instance of GameManager
        // This allows the GameManager to issue movement commands.
        GameManager.Instance.AddDispositionObjectToList(this);

        initialHealth = health;
        _rechargeSecondsInverse = 1 / rechargeSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (rechargeable)
        {
            if (health <= 0)
            {
                recharging = true;
            }

            if (recharging)
            {
                health += initialHealth * _rechargeSecondsInverse * Time.deltaTime;

                if (health >= initialHealth)
                {
                    health = initialHealth;
                    recharging = false;
                }
            }
        }
    }

    // Update the color when changed in the Unity editor
    void OnValidate()
    {
        UpdateDispositionColor();
        _rechargeSecondsInverse = 1 / rechargeSeconds;
    }

    private void UpdateDispositionColor()
    {
        OnDispositionChange();
        if (psr != null)
        {
            psr.material.EnableKeyword("_EMISSION");
            psr.material.SetColor("_Albedo", Color.black);
            psr.material.SetColor("_EmissionColor", disposition.getColor());
            psr.material.color = disposition.getColor();
        }
    }

    /// <summary>
    /// Enable or disable the disposition effect.
    /// </summary>
    /// <param name="enable"></param>
    public void ToggleDisposition(bool enable)
    {
        if (psr)
            psr.enabled = enable;
    }
}
