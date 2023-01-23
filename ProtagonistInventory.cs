using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Holds all the player character's inventory content and settings.
/// </summary>
[Serializable, Tooltip("Holds all the player character's inventory content and settings.")]
public class ProtagonistInventory
{
    //private PlayerController player;
    [Header("Inventory properties")]

    [SerializeField] private float maximumWeight = 0;
    [SerializeField] private float currentWeight = 0;
    [SerializeField] private List<ItemByQuantity> items = new List<ItemByQuantity>();

    public float MaximumWeight => maximumWeight;
    public float CurrentWeight => currentWeight;
    public List<ItemByQuantity> Items => items;
    private float SumItemsWeight => items.Select(match => match.SummedWeight).Sum();

    public void Start(List<ItemByQuantity> items = null, int _maxSlots = 10)
    {
        this.items = items;
    }
    private bool CanAddToInventory(Item item, int quantity = 1)
    {
        float newWeight = this.currentWeight + item.weight * quantity;
        if (newWeight > this.currentWeight)
        {
            Debug.Log($"Este objeto es demasiado pesado.");
            return false;
        }

        return true;
    }
    public bool AddToInventory(Item item, int quantity = 1)
    {
        if (!CanAddToInventory(item, quantity))
        {
            return false;
        }
        var match = FindMatchInInventory(item);

        if (match == null)
        {
            items.Add(new ItemByQuantity(item, quantity));
        }
        else
        {
            match.ModifyQuantity(quantity);
        }

        currentWeight += item.weight * quantity;
        return true;
    }
    private ItemByQuantity FindMatchInInventory(Item item) => items.Find(itemInInventory => itemInInventory.Item == item);
    public void DropItem(Item item)
    {
        if (item == null || !this.items.Any(match => match.Item == item))
        {
            return;
        }

        var match = FindMatchInInventory(item);
        match.ModifyQuantity(-1);
        if (match.Quantity == 0)
        {
            items.Remove(match);
        }
        this.currentWeight -= item.weight;
    }

    public void Load(List<ItemByQuantity> items, float maximumWeight)
    {
        this.maximumWeight = maximumWeight;
        foreach (ItemByQuantity item in items)
        {
            this.items.Add(new ItemByQuantity(item.Item, item.Quantity));
        }
        this.currentWeight = SumItemsWeight;
    }

    public ProtagonistInventoryState SaveState()
    {
        return new ProtagonistInventoryState(this);
    }

    
}