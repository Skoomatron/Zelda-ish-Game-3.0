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

    void Start()
    {

    }
    void Update()
    {

    }
}
