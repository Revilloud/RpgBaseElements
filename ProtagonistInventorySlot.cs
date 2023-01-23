using System;
using UnityEngine;
/// <summary>
/// Representation of a certain quantity of an item in an inventory.
/// </summary>
[Serializable]
public class ProtagonistInventorySlot
{
    public Item item = null;
    public int quantity = 0;

    public float weight => item.weight * quantity;

    public ProtagonistInventorySlot(Item _item = null, int _quantity = 0)
    {
        try
        {
            this.item = _item;
            this.quantity = _quantity;
        }
        catch (Exception ex)
        {
            Debug.LogWarning($"{ex.Message} : {ex.StackTrace}");
        }
    }

    public void ModifyQuantity(int _quantity)
    {
        quantity += _quantity;
    }
}