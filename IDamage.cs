using UnityEngine;
using System;

/// <summary>
/// Allow an entity to attack and be attacked.
/// </summary>
public interface IDamageable
{
    public abstract void Attack();
    public abstract void GetAttacked(Damage[] damageApplied);
    public abstract void Consume(Consumable consumable);
    public abstract void Die();
}