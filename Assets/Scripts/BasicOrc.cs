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
    private Animator animator;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        animator = GetComponent<Animator>();

        if (Vector3.Distance
            (target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius
        )
        {
            animator.SetBool("Moving", true);
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            myRigidbody.MovePosition(temp);
        } else {
            animator.SetBool("Moving", false);
        }
    }
}
