using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{
    [Header("State Machine")]
    public EnemyState currentState;
    [Header("Enemy Health Variables")]
    public FloatValue maxHealth;
    public float health;
    [Header("Enemy Stat Variables")]
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    [Header("Enemy Death Effect")]
    public GameObject deathEffect;
    public float deathDelay = 1;
    public LootTable thisLoot;
    public Vector2 homePosition;
    [Header("Death Signal")]
    public SignalClass roomSignal;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }
    private void OnEnable()
    {
        transform.position = homePosition;

    }
    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnDeath();
            MakeLoot();
            roomSignal.Raise();
            this.gameObject.SetActive(false);
        }
    }

    private void MakeLoot()
    {
        if (thisLoot != null)
        {
            PowerUp current = thisLoot.LootPowerup();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }
    private void OnDeath()
    {
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, deathDelay);
        }
    }
    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }
    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.GetComponent<Enemy>().currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
