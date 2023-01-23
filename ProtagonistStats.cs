using System;
using UnityEngine;

/// <summary>
/// Hold the players statistics.
/// </summary>
[Serializable]
public class ProtagonistStats
{
    [SerializeField] private string name;
    [SerializeField] private float currentEnergy;
    [SerializeField] private float maximumEnergy;
    [SerializeField] private float energyRecoveryRate;
    [SerializeField] private float dodgeCost;
    [SerializeField] private int experience;
    [SerializeField] private int level;
    [SerializeField] private Vector3 respawnPosition;
    [SerializeField] private Vector3 position;

    public string Name => name;
    public float CurrentEnergy => currentEnergy;
    public float MaximumEnergy => maximumEnergy;
    public float EnergyRecoveryRate => energyRecoveryRate;
    public float DodgeCost => dodgeCost;
    public int Experience => experience;
    public int Level => level;
    public Vector3 RespawnPosition => respawnPosition;
    public Vector3 Position => position;

    public ProtagonistStatsState State()
    {
        return new ProtagonistStatsState(this);
    }
    public void Load(ProtagonistStatsState state)
    {
        this.name = state.Name;
        this.currentEnergy = state.CurrentEnergy;
        this.maximumEnergy = state.MaximumEnergy;
        this.energyRecoveryRate = state.EnergyRecoveryRate;
        this.dodgeCost = state.DodgeCost;
        this.experience = state.Experience;
        this.level = state.Level;
        this.respawnPosition = state.RespawnPosition;
        this.position = state.Position;
    }
    public void ChangeCurrentEnergy(float addQuantity)
    {
        this.currentEnergy = Mathf.Clamp(this.currentEnergy + addQuantity, 0, maximumEnergy);
    }
    public void ChangeExperience(int addQuantity)
    {
        this.currentEnergy += addQuantity;
    }
    public void ChangeLevel(int addQuantity)
    {
        this.level += addQuantity; 
    }

    public void ChangePosition(Vector3 position)
    {
        this.position = position;
    }

}