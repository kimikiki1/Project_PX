using UnityEngine;

public class Hazard : MonoBehaviour
{
    [Header("Settings")]
    public SimpleSpawner spawner;

    private void Start()
    {
        if (spawner == null)
        {
            spawner = Object.FindFirstObjectByType<SimpleSpawner>();
        }
    }

    // IMPORTANT: Note the '2D' in the function name and parameter
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("2D Trigger hit by: " + other.name);

        if (other.CompareTag("Player"))
        {
            if (spawner != null)
            {
                spawner.SpawnPlayer();
            }
        }
    }
}