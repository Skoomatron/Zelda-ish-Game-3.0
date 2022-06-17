using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BasicOrc : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator animator;

    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        CheckDistance();
    }
    void CheckDistance()
    {
        if (Vector3.Distance
            (target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius
        )
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
            && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                animator.SetBool("Moving", true);
            } else {
                animator.SetBool("Moving", false);
            }
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
