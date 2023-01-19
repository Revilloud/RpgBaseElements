using UnityEngine;
using System;

[Serializable]
public class ItemDropState
{
    public int id;
    public string name = "";
    public int quantity = 1;
    public float x = 0, y = 0, z = 0;

    public ItemDropState(ItemDrop _itemDrop = null)
    {
        id = _itemDrop.GetInstanceID();
        x = _itemDrop.transform.position.x;
        y = _itemDrop.transform.position.y;
        z = _itemDrop.transform.position.z;
        name = _itemDrop.slot.item.name.ToLower();
        quantity = _itemDrop.slot.quantity;
    }
}