using UnityEngine;

public class Lever : MonoBehaviour
{
    Animator animator;


    [Tooltip("Objetos que se activan o desactivan al activar la palabra")]
    public GameObject[] ObjectsToEdit;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("IsActivated");


            ChangeObjects();
        }
    }


    void ChangeObjects()
    {
        foreach (GameObject obj in ObjectsToEdit)
        {
            if (obj != null)
            {
                obj.SetActive(!obj.activeSelf);
            }
        }
    }
}
