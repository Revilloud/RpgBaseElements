using UnityEngine;
using System;

/// <summary>
/// Basic, saveable representation of all of the player character's information.
/// </summary>
[Serializable, Tooltip("Basic, saveable representation of all of the player character's information.")]
public class ProtagonistState
{
    [SerializeField] private CharacterStatsState characterStats;
    [SerializeField] private ProtagonistStatsState protagonistStats;
    [SerializeField] private ProtagonistInventoryState inventory;
    [SerializeField] private ProtagonistEquipmentState equipment;

    public CharacterStatsState CharacterStats => characterStats;
    public ProtagonistStatsState ProtagonistStats => protagonistStats;
    public ProtagonistInventoryState Inventory => inventory;
    public ProtagonistEquipmentState Equipment => equipment;

    public ProtagonistState(Protagonist protagonist)
    {
        this.characterStats = new CharacterStatsState(protagonist.CStats);
        this.protagonistStats = new ProtagonistStatsState(protagonist.PStats);
        this.inventory = new ProtagonistInventoryState(protagonist.Inventory);
        this.equipment = new ProtagonistEquipmentState(protagonist.Equipment);
    }

    public void SetName(string playerName)
    {
        this.protagonistStats.SetName(playerName);
    }
}