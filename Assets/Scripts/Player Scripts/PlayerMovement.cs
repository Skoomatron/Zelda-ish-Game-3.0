using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public PlayerState currentState;

    // [Header("Health Variables")]
    // public FloatValue currentHealth;
    // public SignalClass playerHealthSignal;

    [Header("Position and Movement")]
    public float speed;
    public VectorValue startingPosition;
    [Header("Inventory")]
    public Inventory playerInventory;
    public SpriteRenderer receivedItem;
    [Header("Attacking and Magic")]
    public Item bow;
    public SignalClass playerHit;
    public SignalClass reduceMagic;
    public GameObject projectile;
    [Header("Invunerability Frame Variables")]
    public Color flashColor;
    public Color defaultColor;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D flashTrigger;
    public SpriteRenderer mySprite;

    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("MoveX", 0);
        animator.SetFloat("MoveY", -1);
        transform.position = startingPosition.initialValue;
    }
    void Update()
    {
        if (currentState == PlayerState.interact)
        {
            return;
        }
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack
        && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (Input.GetButtonDown("Ability") && currentState != PlayerState.attack
        && currentState != PlayerState.stagger)
        {
            if (playerInventory.ItemCheck(bow))
            {
                StartCoroutine(SecondAttackCo());
            }
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
    }
    private IEnumerator AttackCo()
    {
        animator.SetBool("Attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(.15f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }
    private IEnumerator SecondAttackCo()
    {
        currentState = PlayerState.attack;
        yield return null;
        MakeArrow();
        yield return new WaitForSeconds(.15f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }
    private void MakeArrow()
    {
        if (playerInventory.currentMagic > 0)
        {
            Vector2 temp = new Vector2(animator.GetFloat("MoveX"), animator.GetFloat("MoveY"));
            ArrowProjectile arrow = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<ArrowProjectile>();
            arrow.Setup(temp, ArrowDirection());
            playerInventory.ReduceMagic(arrow.magicCost);
            reduceMagic.Raise();
        }
    }
    Vector3 ArrowDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("MoveY"), animator.GetFloat("MoveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    public void RaiseItem()
    {
        if (playerInventory.currentItem != null)
        {
            if (currentState != PlayerState.interact)
            {
                animator.SetBool("FoundItem", true);
                currentState = PlayerState.interact;
                receivedItem.sprite = playerInventory.currentItem.itemSprite;
            } else {
                animator.SetBool("FoundItem", false);
                currentState = PlayerState.idle;
                receivedItem.sprite = null;
            }
        }
    }

    void UpdateAnimationAndMove()
    {
        if(change != Vector3.zero)
        {
            MoveCharacter();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
            animator.SetFloat("MoveX", change.x);
            animator.SetFloat("MoveY", change.y);
            animator.SetBool("Moving", true);
        } else {
            animator.SetBool("Moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }

    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCo(knockTime));
        // currentHealth.runtimeValue -= damage;
        // playerHealthSignal.Raise();
        // if (currentHealth.runtimeValue > 0)
        // {
        // }
        // else
        // {
        //     this.gameObject.SetActive(false);
        // }
    }

    private IEnumerator KnockCo(float knockTime)
    {
        playerHit.Raise();
        if (myRigidbody != null)
        {
            StartCoroutine(FlashCo());
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
    private IEnumerator FlashCo()
    {
        int temp = 0;
        flashTrigger.enabled = false;
        while (temp < numberOfFlashes)
        {
            mySprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = defaultColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        flashTrigger.enabled = true;
    }
}