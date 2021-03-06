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
    public BoxCollider2D physicsCollider;

    void Start()
    {

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
        anim.SetBool("ToggleSpikes", false);
        open = false;
        physicsCollider.enabled = true;
    }
}
