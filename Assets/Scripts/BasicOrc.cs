using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//test
public class BasicOrc : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float testing1;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator animator;

    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        animator = GetComponent<Animator>();

        if (Vector3.Distance
            (target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius
            && currentState == EnemyState.idle || currentState == EnemyState.walk
            && currentState != EnemyState.stagger
        )
        {
            animator.SetBool("Moving", true);
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            myRigidbody.MovePosition(temp);
            ChangeState(EnemyState.walk);
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
