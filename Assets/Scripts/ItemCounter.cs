using UnityEngine;
using TMPro;

public class ItemCounter : MonoBehaviour
{
    public static ItemCounter instance;

    [SerializeField] private TMP_Text counterText;
    public int totalToCollect = 5;

    private int currentCount = 0;

    void Awake()
    {
        instance = this;
        UpdateUI();
    }

    public void AddItem()
    {
        currentCount++;
        if (currentCount > totalToCollect)
            currentCount = totalToCollect;

        UpdateUI();
    }

    void UpdateUI()
    {
        if (counterText != null)
            counterText.text = $"{currentCount}/{totalToCollect}";
    }

    public bool HasCollectedAll()
    {
        return currentCount >= totalToCollect;
    }
}
