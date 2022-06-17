using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // could add a check here to see if the player is in attack state on the pot script initiation
        if (collision.gameObject.CompareTag("Breakable") && this.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PotSmashing>().Smash();
        }
        if (collision.gameObject.CompareTag("Enemies") || collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 differential = hit.transform.position - transform.position;
                differential = differential.normalized * thrust;
                hit.AddForce(differential, ForceMode2D.Impulse);
                if (collision.gameObject.CompareTag("Enemies") && collision.isTrigger)
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    collision.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }
                if (collision.gameObject.CompareTag("Player"))
                {
                    hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    collision.GetComponent<PlayerMovement>().Knock(knockTime);
                }
            }
        }
    }
}
