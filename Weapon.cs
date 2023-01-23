using UnityEngine;

/// <summary>
/// Item wielded by players to damage their enemies.
/// </summary>
[CreateAssetMenu(fileName = "new weapon", menuName = "New/Weapon")]
public class Weapon : Item
{
    /// <summary>
    /// Weapon's tool type.
    /// </summary>
    public enum ToolType
    {
        NOT_TOOL,
        HACKING,
        SLASHING,
        SMITHING,
        FISHING
    }
    /// <summary>
    /// Determines in which hand can the weapon be held.
    /// </summary>
    public enum WeaponSlot
    {
        MAIN_HAND,
        OFF_HAND
    }
    [Header("Weapon properties")]
    public WeaponSlot weaponSlot = WeaponSlot.MAIN_HAND;
    public ToolType toolType = ToolType.NOT_TOOL;
    public Damage[] damagesOnHit;

    protected void Awake()
    {
        itemRole = ItemRole.ARMOR;
    }

    public override void Use()
    {
        base.Use();
    }
}