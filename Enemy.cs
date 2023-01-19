using System;
using UnityEngine;
/// <summary>
/// Controls an enemy character's behaviour.
/// </summary>

public class Enemy : MonoBehaviour, IDamageable
{

    public EnemyData enemyData;
    [Serializable]
    public class EnemyStats
    {
        public int currentHealth;
        public int moveSpeed;
    }

    public EnemyStats stats;

    public void SetState(EnemyState state)
    {
        stats.currentHealth = state.currentHealth;
        this.transform.position = new Vector3(state.x, state.y, state.z);
    }

    public EnemyState GetState()
    {
        return new EnemyState(this);
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void GetAttacked(Weapon weapon)
    {
        throw new System.NotImplementedException();
    }

    public void Consume(Consumable consumable)
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void GetAttacked(Damage[] damageApplied)
    {
        throw new NotImplementedException();
    }
}