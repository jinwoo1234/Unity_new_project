using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class ShootingGame_PlayerHealth : MonoBehaviour
{
    float maxHealth = 1f;
    float currentHealth;
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.value = currentHealth / maxHealth;

    }

    [PunRPC]
   void Damage(float damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth / maxHealth;
        if (healthSlider.value <= 0)
        {
            Destroy(gameObject);
        }

    }
}
