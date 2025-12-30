using UnityEngine;
public class PlayerSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public CameraFollow cameraScript;
    public LevelGoal levelGoalScript; // Drag your LevelGoal object here

    void Start()
    {
        int selectedID = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject prefab = Resources.Load<GameObject>($"Characters/Player{selectedID}");

        if (prefab != null)
        {
            GameObject player = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

            // Assign to Camera
            if (cameraScript != null) cameraScript.target = player.transform;

            // Assign to Level Goal
            if (levelGoalScript != null) levelGoalScript.AssignPlayer(player);
        }
    }
}