using UnityEngine;
using System;

/// <summary>
/// Basic, saveable representation of all of the player character's information.
/// </summary>
[Serializable, Tooltip("Basic, saveable representation of all of the player character's information.")]
public class ProtagonistState
{
    public string name = "Player";
    public int currentHealth = 0;
    public int maxHealth = 0;
    public float moveSpeed = 1;
    public string head = "";
    public string chest = "";
    public string legs = "";
    public string mainHand = "";
    public string offHand = "";
    public float x = 0, y = 0, z = 0;
    public InventoryState inventoryState;
    public int maxSlots = 999;
    public float maxWeight = 999;
    // Inventory items and their quantity.
    public InventorySlotState[] slots;

    public ProtagonistState(Protagonist _player = null)
    {
        if(_player == null)
        {
            return;
        }
        name = _player.name;
        currentHealth = _player.stats.currentHealth;
        maxHealth = _player.stats.maximumHealth;
        moveSpeed = _player.stats.moveSpeed;
        head = _player.equipment.head.name ?? "";
        chest = _player.equipment.chest.name ?? "";
        legs = _player.equipment.legs.name ?? "";
        mainHand = _player.equipment.mainHand.name ?? "";
        offHand = _player.equipment.offHand.name ?? "";
        maxSlots = _player.inventory.maxSlots;
        maxWeight = _player.inventory.maxCarryWeight;
        slots = _player.inventory.SaveState().slots;
        x = _player.transform.position.x;
        y = _player.transform.position.y;
        z = _player.transform.position.z;      
    }
}