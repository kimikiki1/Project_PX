using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // EnemyHealth.cs
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) Die();
    }


    void Die()
    {
        // Optional: play death animation, drop loot, etc.
        Destroy(gameObject);
    }
}
