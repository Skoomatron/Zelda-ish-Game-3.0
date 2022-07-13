using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : BasicOrc
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
                ChangeState(EnemyState.walk);
                animator.SetBool("Moving", true);
            }
        } else if (Vector3.Distance(target.position, transform.position) <= chaseRadius
                && Vector3.Distance(target.position, transform.position) <= attackRadius)
                {
                    StartCoroutine(AttackCo());
                }
    }
    public IEnumerator AttackCo()
    {
        currentState = EnemyState.attack;
        animator.SetBool("Attacking", true);
        yield return new WaitForSeconds(0.5f);
        currentState = EnemyState.walk;
        animator.SetBool("Attacking", false);
    }
}
