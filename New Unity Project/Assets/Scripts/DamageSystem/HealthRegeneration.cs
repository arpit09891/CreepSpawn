using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegeneration : MonoBehaviour {

    // Use this for initialization
    public float healthRegenRate;

    PlayerHealth playerHealth;
    float currentHealth;
    float totalHealth;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if(!playerHealth.isDead)
        {
            RegenerateHealth();
        }
    }
    void RegenerateHealth()
    {
        currentHealth = playerHealth.currentHealth;
        totalHealth = playerHealth.startingHealth;

        if (currentHealth == totalHealth)
            return;

        float heal = healthRegenRate * Time.deltaTime;

        if(currentHealth < totalHealth)
        {
            if((currentHealth + heal) >= totalHealth)
            {
                currentHealth = totalHealth;
                return;
            }
            else
            {
                currentHealth += heal;
            }
            playerHealth.currentHealth = currentHealth;
        }
    }


}
