using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthSlider;
    public FloatValue playerHealth;
    void Start()
    {
        healthSlider.maxValue = playerHealth.initialValue;
        healthSlider.value = playerHealth.runtimeValue;
    }
    public void AddHealth()
    {
        healthSlider.value++;
        playerHealth.runtimeValue++;
        if (healthSlider.value > healthSlider.maxValue)
        {
            healthSlider.value = healthSlider.maxValue;
            playerHealth.runtimeValue = playerHealth.initialValue;
        }
    }
    public void DecreaseHealth(int damage)
    {
        healthSlider.value = playerHealth.runtimeValue;
        if (healthSlider.value < 0)
        {
            healthSlider.value = 0;
            playerHealth.runtimeValue = 0;
        }
    }
}
