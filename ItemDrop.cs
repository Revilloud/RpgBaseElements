using UnityEngine;
public class ItemDrop : Interactable
{
    public InventorySlot slot;
    
    public void PickUp()
    {

    }

    public ItemDropState GetState()
    {
        return new ItemDropState(this);
    }

    public void SetState(Item _item, int _quantity, Vector3 _position)
    {
        transform.position = _position;
        var slot = new InventorySlot(_item, _quantity);
        slot.item = _item;
        slot.quantity = _quantity;
    }
}