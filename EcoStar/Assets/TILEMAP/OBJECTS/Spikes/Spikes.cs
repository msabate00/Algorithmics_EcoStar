using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("Chupamela");
            Debug.Log("La yiyang le gustam el pito");

            Animator animator = collision.GetComponent<Animator>();

            animator.SetTrigger("Defeat");


        }
    }
}
