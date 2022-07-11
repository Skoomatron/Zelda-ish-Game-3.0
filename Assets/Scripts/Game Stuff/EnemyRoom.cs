using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoom : DungeonRoom
{
    public Door[] doors;
    public void CheckEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if(enemies[i].gameObject.activeInHierarchy && i < enemies.Length - 1)
            {
                return;
            }
            OpenDoors();
        }
    }
    public void CloseDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Close();
        }
    }
    public void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Open();
        }
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        CloseDoors();
    }
    // public override void OnTriggerExit2D(Collider2D collision)
    // {
    //     base.OnTriggerExit2D(collision);
    // }
}
