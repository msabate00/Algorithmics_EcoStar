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
            animator.SetTrigger("IsPressed");

            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumperForce, ForceMode2D.Impulse);
        }
    }
}