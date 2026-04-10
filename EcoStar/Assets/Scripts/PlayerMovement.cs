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

    public Vector2 groundcheck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        moveInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(
        groundCheck.position,
        groundCheckRadius,
        groundLayer
        );

        if (Input.GetButtonDown("Jump") &&
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
             }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed,
        rb.linearVelocity.y);
    }
}
