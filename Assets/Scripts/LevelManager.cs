using UnityEngine;
using UnityEngine.SceneManagement; // Required for switching scenes

public class LevelManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject winPanel; // Drag your "Level Complete" panel here

    private bool isLevelOver = false;

    void Start()
    {
        // Make sure the panel is hidden when the level starts
        if (winPanel != null) winPanel.SetActive(false);
    }

    // This is called by your Quest/Goal script
    public void LevelComplete()
    {
        if (isLevelOver) return;
        
        isLevelOver = true;
        Debug.Log("Level Complete!");

        // Show the panel
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            
            // If you have an Animator on the panel, it will play 
            // its "Entry" animation automatically when SetActive is true
        }

        // Optional: Freeze the game so the player doesn't keep moving
        // Time.timeScale = 0f; 
    }

    // Triggered by the "Next Level" Button
    public void LoadNextLevel()
    {
        // Reset time if you froze it
        Time.timeScale = 1f;

        // Get the next scene in the Build Settings list
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if a next scene actually exists
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels! Returning to Menu.");
            SceneManager.LoadScene(0); // Load Main Menu
        }
    }
}