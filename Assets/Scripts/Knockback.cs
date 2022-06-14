using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                enemy.GetComponent<Enemy>().currentState = EnemyState.stagger;
                Vector2 differential = enemy.transform.position - transform.position;
                differential = differential.normalized * thrust;
                enemy.AddForce(differential, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));
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
