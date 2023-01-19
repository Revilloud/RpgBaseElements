using UnityEngine;

/// <summary>
/// Item wielded by players to reduce received damage.
/// </summary>
[CreateAssetMenu(fileName = "new armor", menuName = "New/Armor")]
public class Armor : Item
{
    /// <summary>
    /// Determines in which armor slot will the armor be equipped.
    /// </summary>
    public enum ArmorSlot
    {
        HEAD,
        CHEST,
        LEGS
    }
    [Header("Armor properties")]
    public ArmorSlot armorSlot; // where do you wear the armor.
    public Defence[] defences;  // how much and which damage does the armor mitigates.

}