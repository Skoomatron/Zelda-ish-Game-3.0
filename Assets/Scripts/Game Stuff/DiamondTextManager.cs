using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiamondTextManager : MonoBehaviour
{
    public Inventory playerInventory;
    public TextMeshProUGUI diamondDisplay;
    public void UpdateDiamondCount()
    {
        diamondDisplay.text = "" + playerInventory.diamonds;
    }
}
