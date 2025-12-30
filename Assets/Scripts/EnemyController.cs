using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public Transform groundCheck;
    public float checkDistance = 0.5f;
    public LayerMask groundLayer;

    private bool movingRight = true;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Move enemy
        rb.linearVelocity = new Vector2(movingRight ? speed : -speed, rb.linearVelocity.y);

        // Check if ground ahead exists
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, checkDistance, groundLayer);

        if (!hit)
        {
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        sr.flipX = !sr.flipX;
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * checkDistance);
        }
    }
}
