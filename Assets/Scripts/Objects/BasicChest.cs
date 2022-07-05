using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicChest : Interactables
{
    [Header("Chest Contents")]
    public Item contents;
    public Inventory playerInventory;
    [Header("Chest Mechanics")]
    public bool isOpen;
    public BoolValue storedOpen;
    public SignalClass raiseItem;
    [Header("Chest Text")]
    public GameObject dialogBox;
    public Text dialogText;
    [Header("Chest Animation")]
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = storedOpen.runtimeValue;
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
        dialogText.text = contents.itemName;
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        raiseItem.Raise();
        context.Raise();
        isOpen = true;
        anim.SetBool("Opened", true);
        storedOpen.runtimeValue = true;
    }
    public void ChestOpened()
    {
        dialogBox.SetActive(false);
        raiseItem.Raise();
    }
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}

