using UnityEngine;

public class ProjectileSkibidi : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float espiid;
    public float laiftaim;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (spriteRenderer.flipX)
        {
            rb.linearVelocity = new Vector2 (espiid, 0);
            Destroy(this.gameObject, laiftaim);
        }
        if (!spriteRenderer.flipX)
        {
            rb.linearVelocity = new Vector2(-espiid, 0);
            Destroy(this.gameObject, laiftaim);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
