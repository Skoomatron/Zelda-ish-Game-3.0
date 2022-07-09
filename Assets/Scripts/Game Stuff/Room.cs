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
            for (int x = 0; x < pots.Length; x++)
            {
                ChangeActivation(pots[x], true);
            }
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            for (int x = 0; x < enemies.Length; x++)
            {
                ChangeActivation(enemies[x], false);
            }
            for (int x = 0; x < pots.Length; x++)
            {
                ChangeActivation(pots[x], false);
            }
        }
    }

    void ChangeActivation(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);
    }
}
