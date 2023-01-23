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

    public EnemyStats statsE;

    public void Load(EnemyState state)
    {
        this.statsE.currentHealth = state.CurrentHealth;
        this.transform.position = new Vector3(state.Position.x, state.Position.y, state.Position.z);
    }

    public EnemyState State()
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