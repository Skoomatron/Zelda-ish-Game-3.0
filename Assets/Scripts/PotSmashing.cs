using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotSmashing : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Smash()
    {
        anim.SetBool("Smashed", true);
        StartCoroutine(breakCo());
    }
    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(.2f);
        this.gameObject.SetActive(false);
    }
}
