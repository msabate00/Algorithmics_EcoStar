using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float dashDistance;
    public float dashForce = 3;

    Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Defeat"))
        {
            animator.SetTrigger("Activation");

            collision.GetComponent<PlayerMovement>().railMovement(dashDistance, dashForce);
        }
    }
}
