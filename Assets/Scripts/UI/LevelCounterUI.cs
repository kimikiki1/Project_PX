using UnityEngine;
using TMPro;

public class LevelCounterUI : MonoBehaviour
{
    public static LevelCounterUI instance;
    public TMP_Text counterText;
    public int goal = 5;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        UpdateCounter(0);
    }

    public void UpdateCounter(int current)
    {
        if (counterText != null)
            counterText.text = $"{current}/{goal}";
    }
}
