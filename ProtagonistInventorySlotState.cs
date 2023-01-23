using System;
using UnityEngine;

[Serializable]
public class ProtagonistInventoryItemState
{
    private string name = "";
    private int quantity = 1;

    public string Name => name;
    public int Quantity => quantity;

    public ProtagonistInventoryItemState(ItemByQuantity item)
    {
        this.name = item.Name; ;
        this.quantity = item.Quantity;
    }
}