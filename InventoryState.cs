using System;
using UnityEngine;

/// <summary>
/// Serializable form of the player's inventory.
/// Contains how many of each items there are and 
/// the inventory settings.
/// </summary>
[Serializable]
public class InventoryState
{
    public int maxSlots = 999;
    public float maxWeight = 999;
    // Inventory items and their quantity.
    public InventorySlotState[] slots;

    public InventoryState(Inventory _inventory = null)
    {
        try
        {
            maxSlots = _inventory.maxSlots;
            maxWeight = _inventory.maxCarryWeight;
            int slotsCount = _inventory.slots.Count;
            // Save each item and their respective quantity.
            slots = new InventorySlotState[slotsCount];
            for (int i = 0; i < slotsCount; i++)
            {
                slots[i] = new InventorySlotState() { name = _inventory.slots[i].item.name, quantity = _inventory.slots[i].quantity };
            }
        }
        catch (Exception ex)
        {
            Debug.LogWarning($"{ex.Message} : {ex.StackTrace}");
        }

    }
}