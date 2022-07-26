using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;

    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description;
        if (buttonActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }
    void Start()
    {
        SetTextAndButton("", false);
    }

    void Update()
    {

    }
}
