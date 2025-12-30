using UnityEngine;
using TMPro;

public class PickupUI : MonoBehaviour
{
    public static PickupUI instance;
    public TMP_Text counterText;       // e.g. "0/5"
    public TMP_Text feedbackText;      // Optional: "Picked up Gem"

    public int targetAmount = 5;

    void Awake() => instance = this;

    public void UpdateCounter(int current)
    {
        if (counterText != null)
            counterText.text = $"{current}/{targetAmount}";
    }

    public void ShowFeedback(string msg)
    {
        if (feedbackText != null)
        {
            feedbackText.text = msg;
            // Optional: could fade out after a few seconds
        }
    }
}
