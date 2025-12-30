using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    [Header("Settings")]
    public GameObject playerPrefab; // Drag your character prefab here
    public Transform spawnPoint;    // Drag a spawn location here

    [Header("Assignments")]
    public CameraFollow cameraScript; // Drag Main Camera here
    public LevelGoal levelGoalScript; // Drag your Goal object here

    void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        // 1. Destroy the old player if they exist (for respawning)
        GameObject existingPlayer = GameObject.FindGameObjectWithTag("Player");
        if (existingPlayer != null) Destroy(existingPlayer);

        // 2. Spawn the player
        GameObject newPlayer = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        newPlayer.tag = "Player"; // Force the tag just in case

        // 3. Automatically link the scripts
        if (cameraScript != null)
        {
            cameraScript.target = newPlayer.transform;
        }

        if (levelGoalScript != null)
        {
            levelGoalScript.AssignPlayer(newPlayer);
        }
    }
}