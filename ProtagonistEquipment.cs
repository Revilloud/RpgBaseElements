using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Holds all the player character's armor and weapons information.
/// </summary>
[Serializable, Tooltip("Holds all the player character's armor and weapons information.")]
public class ProtagonistEquipment
{
    [Header("Equipment properties")]
    public Armor head;
    public Armor chest;
    public Armor legs;
    public Weapon mainHand;
    public Weapon offHand;

    /// <summary>
    /// Swaps the current head armor piece.
    /// </summary>
    /// <returns>Currently equipped head piece.</returns>
    public Item EquipWeapon(Weapon _weapon)
    {
        switch (_weapon.weaponSlot)
        {
            case Weapon.WeaponSlot.MAIN_HAND:
                Weapon lastMainHand = mainHand;
                mainHand = _weapon;
                return lastMainHand;
            case Weapon.WeaponSlot.OFF_HAND:
                Weapon lastOffHand = offHand;
                offHand = _weapon;
                return lastOffHand;
            default:
                return null;
        }
    }

    public Item EquipArmor(Armor _armor)
    {
        switch (_armor.armorSlot)
        {
            case Armor.ArmorSlot.HEAD:
                Armor lastHead = head;
                head = _armor;
                return lastHead;
            case Armor.ArmorSlot.CHEST:
                Armor lastChest = chest;
                head = _armor;
                return lastChest;
            case Armor.ArmorSlot.LEGS:
                Armor lastLegs = legs;
                legs = _armor;
                return lastLegs;
            default:
                return null;
        }
    }

    public void UnequipHead()
    {
        if(head != null)
        {
            Protagonist.instance.Inventory.AddToInventory(head);
        }
    }

    public void UnequipChest()
    {
        if(chest != null)
        {
            Protagonist.instance.Inventory.AddToInventory(chest);
        }
    }

    public void UnequipLegs()
    {
        if(legs != null)
        {
            Protagonist.instance.Inventory.AddToInventory(legs);
        }
    }

    public void UnequipMainHand()
    {
        if(mainHand != null)
        {
            Protagonist.instance.Inventory.AddToInventory(mainHand);
        }
    }

    public void UnequipOffHand()
    {
        if (offHand != null)
        {
            Protagonist.instance.Inventory.AddToInventory(offHand);
        }
    }

    public void Load(Armor _head, Armor _chest, Armor _legs, Weapon _mainHand, Weapon _offHand)
    {
        head = _head ?? null;
        chest = _chest ?? null;
        legs = _legs ?? null;
        mainHand = _mainHand ?? null;
        offHand = _offHand ?? null;
    }
}