using UnityEngine;
public class ItemDrop : Interactable
{
    public ItemByQuantity itemSlot;

    private void OnEnable()
    {
        
    }

    public void PickUp()
    {

    }

    public ItemDropState State()
    {
        return new ItemDropState(this);
    }

    public void Load(Item _item, int _quantity, Vector3 _position)
    {
        transform.position = _position;
        var slot = new ProtagonistInventorySlot(_item, _quantity);
        slot.item = _item;
        slot.quantity = _quantity;
    }
}