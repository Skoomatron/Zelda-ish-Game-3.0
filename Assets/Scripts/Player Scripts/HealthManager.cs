using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public Slider healthSlider;
    public FloatValue playerHealth;
    void Start()
    {
        healthSlider.maxValue = playerHealth.initialValue;
        healthSlider.value = playerHealth.initialValue;
        playerHealth.currentHealth = playerHealth.initialValue;
    }
    public void AddHealth()
    {
        healthSlider.value++;
        playerHealth.currentHealth++;
        if (healthSlider.value > healthSlider.maxValue)
        {
            healthSlider.value = healthSlider.maxValue;
            playerHealth.currentHealth = playerHealth.initialValue;
        }
    }
    public void DecreaseHealth(int damage)
    {
        healthSlider.value -= damage;
        playerHealth.currentHealth -= damage;
        if (healthSlider.value < 0)
        {
            healthSlider.value = 0;
            playerHealth.currentHealth = 0;
        }
    }
}
