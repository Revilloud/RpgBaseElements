using System;
using UnityEngine;

[Serializable]
public class EnemyState
{
    [SerializeField] private int id = 0;
    [SerializeField] private int currentHealth = 0;
    [SerializeField] private float x = 0, y = 0, z = 0;

    public int Id => id;
    public int CurrentHealth => currentHealth;
    public Vector3 Position => new Vector3(x,y,z);

    public EnemyState(Enemy enemy)
    {

        this.id = enemy.GetInstanceID();
        this.currentHealth = enemy.statsE.currentHealth;
        this.x = enemy.transform.position.x;
        this.y = enemy.transform.position.y;
        this.z = enemy.transform.position.z;
    }
}