using System;
using UnityEngine;

/// <summary>
/// Serializable form of the player's inventory.
/// Contains how many of each items there are and 
/// the inventory settings.
/// </summary>
[Serializable]
public class ProtagonistInventoryState
{
    [SerializeField] private float currentWeight = 0;
    [SerializeField] private float maximumWeight = 999;
    [SerializeField] private ProtagonistInventoryItemState[] itemState;

    public float CurrentWeight => currentWeight;
    public float MaximumWeight => maximumWeight;
    public ProtagonistInventoryItemState[] ItemState => itemState;

    public ProtagonistInventoryState(ProtagonistInventory inventory)
    {
        if (inventory == null) return;

        this.currentWeight = inventory.CurrentWeight;
        this.maximumWeight = inventory.MaximumWeight;
        this.itemState = new ProtagonistInventoryItemState[inventory.Items.Count];
        
        foreach (var match in inventory.Items)
        {
            int index = inventory.Items.IndexOf(match);
            itemState[index] = new ProtagonistInventoryItemState(match);
        }
    }
}