using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] PlayerAnimationManager animationManager;

    [SerializeField] Legs legs;

    float rollSpeed = 5;
    float walkSpeed = 7;
    float midAirSpeed = 4;

    float jumpSpeed = 5.25f;

    float currentSpeed;

    float moveDir = 0;

    private void Start()
    {
        currentSpeed = rollSpeed;
    }

    private void Update()
    {
        HandleMovement();
        HandleAnimation();
    }

    private void HandleMovement()
    {
        rb.velocity = new Vector2(currentSpeed * moveDir, rb.velocity.y);
    }

    private void HandleAnimation()
    {
        animationManager.setMovementAnimation(moveDir != 0);
    }


    public void Move(float moveInput)
    {
        moveDir = moveInput;
        transform.localScale = new Vector2(moveInput, transform.localScale.y);
    }

    public void StopMove()
    {
        moveDir = 0;
    }

    public void Jump()
    {
        if (legs.gameObject.activeSelf)
        {
            if (legs.GetIsTouchingGround())
            {
                currentSpeed = midAirSpeed;
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
        }
    }

    public void RestoreBodyPart(BodyPart bodyPart)
    {
        switch (bodyPart.GetBodyPartType())
        {
            case BodyPart.BodyPartType.Legs:
                RestoreLegs();
                break;

        }
    }

    private void RestoreLegs()
    {
        legs.gameObject.SetActive(true);
        animationManager.SwitchToLegMovement();
        currentSpeed = walkSpeed;
        transform.position = new Vector2(transform.position.x, transform.position.y + .2f);
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.offset = new Vector2(0, -.17f);
        boxCollider2D.size = new Vector2(.35f, .6f);
    }
}
