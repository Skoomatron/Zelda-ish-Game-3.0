using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool active;
    public BoolValue storedValue;
    public Door thisDoor;
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        active = storedValue.runtimeValue;
        if (active)
        {
            ActivateSwitch();
        }
    }
    public void ActivateSwitch()
    {
        active = true;
        storedValue.runtimeValue = active;
        thisDoor.Open();
        anim.SetBool("Toggle", true);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActivateSwitch();
        }
    }
}
