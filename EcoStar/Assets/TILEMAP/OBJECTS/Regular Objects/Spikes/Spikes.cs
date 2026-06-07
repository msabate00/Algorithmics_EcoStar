using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Defeat"))
        {
            print("Chupamela");
            Debug.Log("La yiyang le gustam el pito");

            Animator animator = collision.GetComponent<Animator>();

            animator.SetTrigger("Defeat");
        }
    }
}
