using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [Header("Level Items")]
    public int gemsCollected = 0;

    // Called by PickupItem when player picks up an item
    public void CollectItem(string itemName)
    {
        if (itemName == "Gem") // For now, only track gems
        {
            gemsCollected++;
            Debug.Log($"Collected {itemName}. Total: {gemsCollected}");

            // Optional: update UI
            if (LevelCounterUI.instance != null)
                LevelCounterUI.instance.UpdateCounter(gemsCollected);
        }
    }
}
