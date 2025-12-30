using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Transform targetPoint;
    private SpriteRenderer sr;

    void Start()
    {
        targetPoint = pointB;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (targetPoint == null) return;

        // Move enemy towards target point
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // Flip sprite based on movement direction
        if (transform.position.x < targetPoint.position.x) sr.flipX = false;
        else sr.flipX = true;

        // Switch target when reached
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.05f)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
        }
    }

    void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(pointA.position, 0.1f);
            Gizmos.DrawSphere(pointB.position, 0.1f);
            Gizmos.DrawLine(pointA.position, pointB.position);
        }
    }
}
