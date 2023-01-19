using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Holds all the player character's armor and weapons information.
/// </summary>
[Serializable, Tooltip("Holds all the player character's armor and weapons information.")]
public class Equipment
{
    [Header("Equipment properties")]
    public Armor head;
    public Armor chest;
    public Armor legs;
    public Weapon mainHand;
    public Weapon offHand;

    [Header("Equipment UI")]
    public Image headImage;
    public Image chestImage;
    public Image legsImage;
    public Image mainHandImage;
    public Image offHandImage;

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
            Protagonist.instance.inventory.AddItem(head);
        }
    }

    public void UnequipChest()
    {
        if(chest != null)
        {
            Protagonist.instance.inventory.AddItem(chest);
        }
    }

    public void UnequipLegs()
    {
        if(legs != null)
        {
            Protagonist.instance.inventory.AddItem(legs);
        }
    }

    public void UnequipMainHand()
    {
        if(mainHand != null)
        {
            Protagonist.instance.inventory.AddItem(mainHand);
        }
    }

    public void UnequipOffHand()
    {
        if (offHand != null)
        {
            Protagonist.instance.inventory.AddItem(offHand);
        }
    }

    public void Load(Armor _head, Armor _chest, Armor _legs, Weapon _mainHand, Weapon _offHand)
    {
        try
        {
            head = _head;
            chest = _chest;
            legs = _legs;
            mainHand = _mainHand;
            offHand = _offHand;
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            throw;
        }
        
    }
}