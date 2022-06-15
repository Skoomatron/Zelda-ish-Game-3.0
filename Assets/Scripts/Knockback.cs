using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Breakable"))
        {
            collision.GetComponent<PotSmashing>().Smash();
        }
        if (collision.gameObject.CompareTag("Enemies") || collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                Vector2 differential = hit.transform.position - transform.position;
                differential = differential.normalized * thrust;
                hit.AddForce(differential, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(hit));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
        }
    }
}
