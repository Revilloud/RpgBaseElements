using System;
using UnityEngine;

[Serializable]
public class ProtagonistStatsState
{
    [SerializeField] private string name;
    [SerializeField] private float currentEnergy;
    [SerializeField] private float maximumEnergy;
    [SerializeField] private float energyRecoveryRate;
    [SerializeField] private float dodgeCost;
    [SerializeField] private int experience;
    [SerializeField] private int level;
    [SerializeField] private float rx, ry, rz;
    [SerializeField] private float px, py,pz;

    public string Name => this.name;
    public float CurrentEnergy => this.currentEnergy;
    public float MaximumEnergy => this.maximumEnergy;
    public int Experience => this.experience;
    public float EnergyRecoveryRate => this.energyRecoveryRate;
    public float DodgeCost => this.dodgeCost;
    public int Level => this.level;
    public Vector3 RespawnPosition => new Vector3(rx, ry, rz);
    public Vector3 Position => new Vector3(px,py,pz);
    public ProtagonistStatsState(ProtagonistStats stats)
    {
        this.name = stats.Name;
        this.currentEnergy = stats.CurrentEnergy;
        this.maximumEnergy = stats.MaximumEnergy;
        this.experience = stats.Experience;
        this.level = stats.Level;
        this.rx = stats.Position.x;
        this.ry = stats.Position.y;
        this.rz = stats.Position.z;
        this.px = stats.RespawnPosition.x;
        this.py = stats.RespawnPosition.y;
        this.pz = stats.RespawnPosition.z;
    }

    public void SetName(string playerName)
    {
        this.name = playerName;
    }
}