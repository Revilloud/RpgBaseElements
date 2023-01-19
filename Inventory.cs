using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Holds all the player character's inventory content and settings.
/// </summary>
[Serializable, Tooltip("Holds all the player character's inventory content and settings.")]
public class Inventory
{
    //private PlayerController player;
    [Header("Inventory properties")]

    public int maxSlots;
    public float maxCarryWeight;
    public List<InventorySlot> slots;

    [Header("Inventory UI")]

    public Transform uiItemContainer;
    public GameObject uiSlotPrefab;

    /// <summary>
    ///  Sum of the collective weight of all the items in the player's inventory.
    /// </summary>
    private float currentWeight => slots.Select(x => x.weight).Sum();
    public void Start(List<InventorySlot> _slots = null, int _maxSlots = 10)
    {
        slots = _slots;
    }

    /// <summary>
    /// Tries to place a certain quantity of items in the inventory.
    /// </summary>
    /// <param name="item">Item to add.</param>
    /// <param name="quantity">How many items to add.</param>
    /// <returns>How many items couldn't be added.</returns>
    public InventorySlot AddItem(Item _item, int _quantity = 1)
    {
        InventorySlot slot = new InventorySlot(_item, _quantity);

        if (FindAllInInventory(_item).Count() > 0)
        {
            // If the item is present in the inventory, increase it's quantity.
            slots.Find(x => x.item == _item).ModifyQuantity(_quantity);
        }
        else
        {
            CreateSlot(_item, _quantity);
        }

        return slot;
    }

    public void CreateSlot(Item _item, int _quantity = 1)
    {
        var newSlot = GameObject.Instantiate(uiSlotPrefab, uiItemContainer).GetComponent<InventorySlotController>();
        slots.Add(newSlot.GetComponent<InventorySlot>());
        newSlot.Start(new InventorySlot(_item, _quantity));
    }

    private void UpdateInventoryUI()
    {
        ClearInventoryUI();
        foreach(InventorySlot itemSlot in slots)
        {

        }
    }

    private void ClearInventoryUI()
    {
        foreach(Transform transformx in uiItemContainer)
        {
            GameObject.Destroy(transformx);
        }
    }

    private IEnumerable<InventorySlot> FindAllInInventory(Item _item)
    {
        return slots.FindAll(x => x.item == _item);
    }

    public void Load(IEnumerable<InventorySlot> _slots, int _maxSlots, float _maxWeight)
    {
        maxSlots = _maxSlots;
        maxCarryWeight = _maxWeight;
        slots = _slots.ToList();
    }
    public InventoryState SaveState()
    {
        return new InventoryState(this);
    }

    
}