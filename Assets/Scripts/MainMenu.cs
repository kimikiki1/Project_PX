using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Call this from the button's OnClick()
    public void LoadLevel(string levelName)
    {
        // Make sure the scene is added to Build Settings
        SceneManager.LoadScene(levelName);
    }

    // Optional: Quit game button
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // Only visible in Editor
    }
}
