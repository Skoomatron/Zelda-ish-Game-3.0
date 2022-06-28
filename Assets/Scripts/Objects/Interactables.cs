using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
     public SignalClass context;
    public bool playerInRange;
    void Start()
    {

    }
    void Update()
    {

    }
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            context.Raise();
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
