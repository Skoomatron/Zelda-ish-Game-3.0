using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRigidbody;
    void Start()
    {

    }
    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidbody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies") || collision.gameObject.CompareTag("Walls") || collision.gameObject.CompareTag("Breakable"))
        {
            Destroy(this.gameObject);
        }
    }
}
