using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<string, int> itemCounts = new Dictionary<string, int>();

    public void CollectItem(string itemName)
    {
        if (!itemCounts.ContainsKey(itemName))
            itemCounts[itemName] = 0;

        itemCounts[itemName]++;
    }

    public int GetItemCount(string itemName)
    {
        return itemCounts.ContainsKey(itemName) ? itemCounts[itemName] : 0;
    }
}
