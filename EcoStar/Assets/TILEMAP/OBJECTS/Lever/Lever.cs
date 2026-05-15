using UnityEngine;

public class Lever : MonoBehaviour
{
    Animator animator;


    [Tooltip("Objetos que se activan o desactivan al activar la palabra")]
    public GameObject[] ObjectsToEdit;


    public bool isActive;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("IsActivated");


            if (isActive)
            {
                isActive = false;
            }
            else
            {
                isActive = true;
            }


            foreach (GameObject obj in ObjectsToEdit)
            {
                if (obj != null)
                {
                    obj.SetActive(isActive);
                }
            }
        }
    }
}
