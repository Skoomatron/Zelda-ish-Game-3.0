using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [Header("Knockback Parameters")]
    public float thrust;
    public float knockTime;
    [Header("Damage Variable")]
    public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
                    if (collision.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        collision.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                    }
                }
            }
        }
    }
}
