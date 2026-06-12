using System.Collections;
using UnityEngine;

public class Button : MonoBehaviour
{
    Animator animator;


    [Tooltip("Objetos que se activan o desactivan al activar la palabra")]
    public GameObject[] ObjectsToEdit;

    public float secondsToWait;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsPressed", true);

            StartCoroutine(ButtonSequence());
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


    private IEnumerator ButtonSequence()
    {
        ChangeObjects();

        animator.SetBool("IsPressed", true);


        yield return new WaitForSeconds(secondsToWait);

        
        ChangeObjects();

        animator.SetBool("IsPressed", false);
    }
}
