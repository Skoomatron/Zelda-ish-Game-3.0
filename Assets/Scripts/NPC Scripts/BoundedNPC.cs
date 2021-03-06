using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Sign
{
    private Vector3 npcDirection;
    private Transform myTransform;
    private Rigidbody2D myRigidbody;
    private Animator animator;
    private bool moving;
    [Header("Boundary Area")]
    public Collider2D bounds;
    [Header("Move Variables")]
    public float speed;
    public float minMoveTime;
    public float maxMoveTime;
    public float minWaitTime;
    public float maxWaitTime;
    private float moveDecay;
    private float waitDecay;
    void Start()
    {
        waitDecay = Random.Range(minWaitTime, maxWaitTime);
        moveDecay = Random.Range(minMoveTime, maxMoveTime);
        animator = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }
    public override void Update()
    {
        base.Update();
        if (moving)
        {
            moveDecay -= Time.deltaTime;
            if (moveDecay <= 0)
            {
                moveDecay = Random.Range(minMoveTime, maxMoveTime);
                moving = false;
            }
            if(!playerInRange)
            {
                NPCMove();
            }
        }
        else
        {
            waitDecay -= Time.deltaTime;
            if (waitDecay <= 0)
            {
                moving = true;
                waitDecay = Random.Range(minWaitTime, maxWaitTime);
                ChooseDifferentDir();
            }
        }
    }
    void UpdateAnimation()
    {
        animator.SetFloat("MoveX", npcDirection.x);
        animator.SetFloat("MoveY", npcDirection.y);
    }
    private void ChooseDifferentDir()
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
        ChooseDifferentDir();
    }
}
