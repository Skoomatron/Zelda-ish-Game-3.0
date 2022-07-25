using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("Item UI Parameters")]
    [SerializeField] private TextMeshProUGUI itemNumberText;
    [SerializeField] private Image itemImage;
    [Header("Item Variables")]
    public Sprite itemSprite;
    public int numberHeld;
    public string itemDescription;
    public InventoryItem thisItem;
    public InventoryManager thisManager;
    void Start()
    {

    }

    void Update()
    {

    }
}
