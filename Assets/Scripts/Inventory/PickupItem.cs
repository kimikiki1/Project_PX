using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName = "Gem";
    public KeyCode pickupKey = KeyCode.L; // Changed to L

    private bool playerInRange = false;
    private PlayerInventory playerInv;

    void Update()
    {
        // Check for L key and ensure player is standing near the item
        if (playerInRange && Input.GetKeyDown(pickupKey))
        {
            // 1. Increment item count in inventory
            if (playerInv != null)
            {
                playerInv.CollectItem(itemName);

                // 2. Update the general Counter UI (if you have one)
                if (LevelCounterUI.instance != null)
                {
                    LevelCounterUI.instance.UpdateCounter(playerInv.GetItemCount(itemName));
                }

                // 3. FORCE the Objective Board to refresh immediately
                LevelGoal goal = Object.FindFirstObjectByType<LevelGoal>();
                if (goal != null)
                {
                    // This ensures the "0/5" updates to "1/5" the instant you press L
                    goal.RefreshProgress();
                }

                // 4. Cleanup
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInv = collision.GetComponent<PlayerInventory>();
            if (playerInv != null) playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}