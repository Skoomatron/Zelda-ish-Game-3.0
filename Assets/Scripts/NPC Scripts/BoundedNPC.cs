using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Interactables
{
    private Vector3 npcDirection;
    private Transform myTransform;
    private Rigibody2d myRigidbody;
    public float speed;
    void Start()
    {
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    private void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch(direction)
        {
            case 0:
                npcDirection = Vector3.right;
                break;
            case 1:
                npcDirection = Vector3.up;
                break;
            case 2:
                npcDirection = Vector3.left;
                break;
            case 3:
                npcDirection = Vector3.down;
                break;
            default:
        }
    }
    private void NPCMove()
    {
        myRigidbody.MovePosition(myTransform.position + npcDirection * speed * Time.deltaTime);
    }
}
