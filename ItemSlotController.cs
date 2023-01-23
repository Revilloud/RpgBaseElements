using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 
/// </summary>
public class InventorySlotController : MonoBehaviour
{
    private Protagonist parent;
    public ProtagonistInventorySlot slot; 
    public Image uiIcon;
    public TextMeshPro uiQuantity;

    public void Start(ProtagonistInventorySlot _slot)
    {
        parent = Protagonist.instance;
        slot = _slot;
        Update(_slot);
    }

    public void Update(ProtagonistInventorySlot _slot)
    {
        uiIcon.sprite = _slot.item.uiIcon;
        uiQuantity.text = _slot.quantity.ToString();
    }

    public void Use()
    {
        Protagonist.instance.UseItem(slot.item);
    }
}
