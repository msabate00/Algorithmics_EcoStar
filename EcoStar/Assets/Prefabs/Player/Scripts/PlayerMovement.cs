using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 12f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    bool isGrounded;
    float moveInput;

    bool isDefeat = false;

    
    bool isRolling = false;

    // Update is called once per frame
    void Update()
    {
        if (!isDefeat)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
            );

            if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) &&
            isGrounded)
            {
                rb.linearVelocity = new
               Vector2(rb.linearVelocity.x, jumpForce);
            }

            if (spriteRenderer != null)
            {
                if (moveInput > 0) spriteRenderer.flipX = false;
                else if (moveInput < 0) spriteRenderer.flipX = true;
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                if (animator != null) animator.SetTrigger("Attack");
            }

            if (animator != null)
            {
                animator.SetFloat("Speed", Mathf.Abs(moveInput));
                animator.SetBool("Grounded", isGrounded);
                animator.SetFloat("VerticalSpeed", rb.linearVelocity.y);

                if (Input.GetMouseButtonDown(0) && isRolling == false)
                {
                    animator.SetTrigger("Attack");
                    isRolling = true;
                    rb.linearVelocity = new Vector2(moveSpeed * 2, rb.linearVelocity.y);
                    StartCoroutine(StopRolling());
                }

            }
        }
    }

    private void FixedUpdate()
    {
        if (isRolling == false)
        {
            rb.linearVelocity = new Vector2(moveInput * moveSpeed,
            rb.linearVelocity.y);
        }
        if(isRolling == true)
        {
            if (spriteRenderer.flipX == true)
            {
                rb.linearVelocity = new Vector2(-moveSpeed * 4f, rb.linearVelocityY);
            }
            else
            {
                rb.linearVelocity = new Vector2(moveSpeed * 4f, rb.linearVelocityY);
            }
        }
    }

    IEnumerator StopRolling()
    {
        yield return new WaitForSeconds(0.35f);
        isRolling = false;
    }

    public void StartingDefeat()
    {
        isDefeat = true;
    }
}
