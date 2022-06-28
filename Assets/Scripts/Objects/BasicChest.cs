using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicChest : Interactables
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public SignalClass raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!isOpen)
            {
                OpenChest();
            } else {
                ChestOpened();
            }
        }
    }
    public void OpenChest()
    {
        dialogBox.SetActive(true);
        dialogBox.text = contents.itemName;
        playerInventory.currentItem = contents;
    }
    public void ChestOpened()
    {

    }
}
