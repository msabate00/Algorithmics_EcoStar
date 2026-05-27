using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public Vector2 respawnPoin;


    private void Start()
    {
        respawnPoin = new Vector2(transform.position.x, transform.position.y);
    }
    public void Respawn()
    {
        transform.position = respawnPoin;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            respawnPoin = new Vector2(collision.transform.position.x, collision.transform.position.y + 1);
        }
    }
}
