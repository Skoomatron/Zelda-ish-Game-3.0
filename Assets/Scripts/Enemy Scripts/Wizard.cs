using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : BasicOrc
{
    public GameObject projectile;
    public float fireDelay;
    private float fireDelaySeconds;
    public bool canFire = true;
    private void update()
    {
        fireDelaySeconds -= Time.deltaTime;
        if (fireDelaySeconds <= 0)
        {
            canFire = true;
            fireDelaySeconds = fireDelay;
        }
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
                    if (canFire)
                    {
                        Vector3 tempVector = target.transform.position - transform.position;
                        GameObject currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
                        currentProjectile.GetComponent<Projectile>().Launch(tempVector);
                        canFire = false;
                        ChangeState(EnemyState.walk);
                        animator.SetBool("Moving", true);
                    }
                }
                else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
                {
                    animator.SetBool("Moving", false);
                }
            }

    }
}
