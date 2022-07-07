using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : BasicOrc
{
    public GameObject projectile;
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
                    Vector3 tempVector = transform.position - target.transform.position;
                    GameObject currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
                    currentProjectile.GetComponent<Projectile>().Launch(tempVector);
                    ChangeState(EnemyState.walk);
                    animator.SetBool("Moving", true);
                }
                else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
                {
                    animator.SetBool("Moving", false);
                }
            }
    }
}
