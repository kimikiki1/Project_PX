using UnityEngine;

public class PlayerAttackHitbox : MonoBehaviour
{
    public int damage = 1;
    public float knockbackForce = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Only pass 1 argument
            }

        }
    }
}
