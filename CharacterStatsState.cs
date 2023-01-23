using System;
using UnityEngine;

[Serializable]
public class CharacterStatsState
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maximumHealth;
    [SerializeField] private float moveSpeed;

    public int CurrentHealth => currentHealth;
    public int MaximumHealth => maximumHealth;
    public float MoveSpeed => moveSpeed;

    public CharacterStatsState(CharacterStats stats)
    {
        this.currentHealth = stats.CurrentHealth;
        this.maximumHealth = stats.MaximumHealth;
        this.moveSpeed = stats.MoveSpeed;
    }

    public void Load(CharacterStats stats)
    {
        this.currentHealth = stats.CurrentHealth;
        this.maximumHealth = stats.MaximumHealth;
        this.moveSpeed = stats.MoveSpeed;
    }
}
