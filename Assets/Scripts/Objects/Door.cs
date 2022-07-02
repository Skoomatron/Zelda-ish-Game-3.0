using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}
public class Door : Interactables
{
    [Header("Door Variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Animator anim;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
        doorSprite = GetComponent<SpriteRenderer>();
        physicsCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerInRange && thisDoorType == DoorType.key)
            {
                if (playerInventory.numberOfKeyItems > 0)
                {
                    playerInventory.numberOfKeyItems--;
                    Open();
                }

            }
        }
    }
    public void Open()
    {
        anim.SetBool("ToggleSpikes", true);
        open = true;
        physicsCollider.enabled = false;
    }
    public void Close()
    {

    }
}
