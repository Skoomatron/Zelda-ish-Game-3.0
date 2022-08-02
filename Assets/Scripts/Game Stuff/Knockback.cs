using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Knockback : MonoBehaviour
{
    [Header("Knockback Parameters")]
    [SerializeField] private float thrust;
    [SerializeField] private float knockTime;
    [SerializeField] private string collisionTag;
    // [Header("Damage Variable")]
    // public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.CompareTag("Breakable") && this.gameObject.CompareTag("Player"))
        // {
        //     collision.GetComponent<PotSmashing>().Smash();
        // }
        if (collision.gameObject.CompareTag(collisionTag))
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector3 differential = hit.transform.position - transform.position;
                differential = differential.normalized * thrust;
                hit.DOMove(hit.transform.position + differential, knockTime);
                if (collision.gameObject.CompareTag("Enemies") && collision.isTrigger)
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    collision.GetComponent<Enemy>().Knock(hit, knockTime);
                }
                if (collision.gameObject.CompareTag("Player"))
                {
                    if (collision.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        collision.GetComponent<PlayerMovement>().Knock(knockTime);
                    }
                }
            }
        }
    }
}
