using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Interactables
{
    private Vector3 npcDirection;
    private Transform myTransform;
    private Rigidbody2D myRigidbody;
    private Animator animator;
    public Collider2D bounds;
    public float speed;
    void Start()
    {
        animator = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }
    void Update()
    {
        if(!playerInRange)
        {
            NPCMove();
        }
    }
    void UpdateAnimation()
    {
        animator.SetFloat("MoveX", npcDirection.x);
        animator.SetFloat("MoveY", npcDirection.y);
    }
    private void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch(direction)
        {
            case 0:
                npcDirection = Vector3.right;
                break;
            case 1:
                npcDirection = Vector3.up;
                break;
            case 2:
                npcDirection = Vector3.left;
                break;
            case 3:
                npcDirection = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }
    private void NPCMove()
    {
        Vector3 temp = myTransform.position + npcDirection * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp))
        {
            myRigidbody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 temp = npcDirection;
        ChangeDirection();
        int loops = 0;
        while(temp == npcDirection && loops < 50)
        {
            loops++;
            ChangeDirection();
        }

    }
}
