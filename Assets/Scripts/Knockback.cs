using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy)
            {
                enemy.isKinematic = false;
                Vector2 differential = enemy.transform.position - transform.position;
                differential = differential.normalized * thrust;
                enemy.AddForce(differential, ForceMode2D.Impulse);
                enemy.isKinematic = true;
            }
        }
    }
}
