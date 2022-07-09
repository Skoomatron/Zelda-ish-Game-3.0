using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Enemy[] enemies;
    public PotSmashing[] pots;

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            for (int x = 0; x < enemies.Length; x++)
            {
                ChangeActivation(enemies[x], true);
            }
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {

        }
    }

    void ChangeActivation(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);
    }
}
