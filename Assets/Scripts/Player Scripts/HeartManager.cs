using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [Header("Heart Art")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    [Header("Heart Parameters")]
    public FloatValue heartContainers;
    public FloatValue currentPlayerHealth;
    void Start()
    {
        initHearts();
    }
    public void initHearts()
    {
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }
    public void updateHearts()
    {
        float tempHealth = currentPlayerHealth.runtimeValue;
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            if (i <= tempHealth - 1)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}
