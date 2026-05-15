using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float jumperForce;

    Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>();


            animator.SetTrigger("IsPressed");

            rigidbody.linearVelocity = Vector2.zero;

            rigidbody.AddForce(Vector2.up * jumperForce, ForceMode2D.Impulse);
        }
    }
}