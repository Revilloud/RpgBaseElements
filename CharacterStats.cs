using System;
using UnityEngine;

[Serializable]
public class CharacterStats
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maximumHealth;
    [SerializeField] private float moveSpeed;
    public int CurrentHealth => currentHealth;
    public int MaximumHealth => maximumHealth;
    public float MoveSpeed => moveSpeed;

    public CharacterStatsState State()
    {
        return new CharacterStatsState(this);
    }
    public void Load(CharacterStatsState state)
    {
        this.currentHealth = state.CurrentHealth;
        this.maximumHealth = state.MaximumHealth;
        this.moveSpeed = state.MoveSpeed;
    }
    public float ChangeHealth(int addQuantity)
    {
        this.currentHealth = Mathf.Clamp(this.currentHealth + addQuantity, 0, maximumHealth);
        return this.currentHealth;
    }
    public float ChangeMoveSpeed(float addQuantity)
    {
        this.moveSpeed = Mathf.Clamp(this.moveSpeed + addQuantity, 0, 10);
        return this.moveSpeed;
    }
    public float ChangeMaximumHealth(int addQuantity)
    {
        this.maximumHealth = Mathf.Clamp(this.maximumHealth + addQuantity, 0, 10);
        return this.maximumHealth;
    }
    
}
    