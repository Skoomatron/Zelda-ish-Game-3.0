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

    // Update is called once per frame
    void Update()
    {

    }

    public void Smash()
    {
        anim.SetBool("Smashed", true);
    }
}
