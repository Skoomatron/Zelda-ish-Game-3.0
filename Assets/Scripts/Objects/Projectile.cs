using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Parameters")]
    public float projectileSpeed;
    public Vector2 directionToMove;
    [Header("Projectile Duration")]
    public float lifetime;
    private float decayTime;
    public Rigidbody2D myRigidBody;
    void Start()
    {
        decayTime = lifetime;
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        decayTime -= Time.deltaTime;
        if (decayTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Launch(Vector2 initialDestination)
    {
        myRigidBody.velocity = initialDestination * projectileSpeed;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
