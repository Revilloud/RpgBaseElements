using UnityEngine;

/// <summary>
/// Item consumed by players to restore health points.
/// </summary>
[CreateAssetMenu(fileName = "new consumable", menuName = "New/Consumable")]
public class Consumable : Item
{
    [Header("Consumable properties")]
    public int healthRestore = 0;

    protected void Awake()
    {
        itemRole = ItemRole.CONSUMABLE;
    }
}