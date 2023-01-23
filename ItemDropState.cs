using UnityEngine;
using System;

[Serializable]
public class ItemDropState
{
    [SerializeField] private int id;
    [SerializeField] private string name = "";
    [SerializeField] private int quantity = 1;
    [SerializeField] private float x = 0, y = 0, z = 0;

    public int Id => this.id;
    public string Name => this.name;
    public int Quantity => this.quantity;
    public Vector3 Position => new Vector3(x, y, z);
    public ItemDropState(ItemDrop itemDrop)
    {
        this.id = itemDrop.GetInstanceID();
        this.x = itemDrop.transform.position.x;
        this.y = itemDrop.transform.position.y;
        this.z = itemDrop.transform.position.z;
        this.name = itemDrop.itemSlot.Item.name.ToLower();
        this.quantity = itemDrop.itemSlot.Quantity;
    }
}