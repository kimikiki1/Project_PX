using UnityEngine;
using TMPro;

public class PickupPromptUI : MonoBehaviour
{
    public static PickupPromptUI instance;

    [SerializeField] private TMP_Text promptText;

    void Awake()
    {
        instance = this;
        promptText.gameObject.SetActive(false);
    }

    public void ShowPrompt(string itemName)
    {
        promptText.text = $"Press K to pick up {itemName}";
        promptText.gameObject.SetActive(true);
    }

    public void HidePrompt()
    {
        promptText.gameObject.SetActive(false);
    }
}
