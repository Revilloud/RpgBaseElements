using System;
using UnityEngine;
/// <summary>
/// Representation of a certain quantity of an item in an inventory.
/// </summary>
[Serializable]
public class ItemByQuantity
{
    [SerializeField] private Item item = null;
    [SerializeField] private int quantity = 0;
    public float SummedWeight => item.weight * quantity;
    public Item Item => item;
    public string Name => item.name;
    public int Quantity => quantity;

    public ItemByQuantity(Item item = null, int quantity = 0)
    {
        this.item = item;
        this.quantity = quantity;
    }

    public void ModifyQuantity(int addQuantity)
    {
        this.quantity += addQuantity;
    }
}