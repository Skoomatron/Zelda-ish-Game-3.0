using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool active;
    public BoolValue storedValue;
    public Sprite activeSprite;
    private SpriteRenderer thisSprite;
    public Door thisDoor;
    public Animator anim;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        active = storedValue.runtimeValue;
    }
    public void ActivateSwitch()
    {
        anim.SetActive("Toggle", true);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            active = true;
            storedValue.runtimeValue = active;
            thisDoor.Open();
            ActivateSwitch();
        }
    }
}
