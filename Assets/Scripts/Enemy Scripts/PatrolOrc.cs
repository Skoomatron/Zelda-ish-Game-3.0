using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolOrc : BasicOrc
{
    public Transform[] path;
    public int currentPoint;
    public Transform destination;
    public override void CheckDistance()
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
                ChangeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                animator.SetBool("Moving", true);
            }
            else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
            {

            }
        }
    }
}
