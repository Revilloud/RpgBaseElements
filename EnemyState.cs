using System;
using UnityEngine;

/// <summary>
///  Saveable representation of an enemy controller.
/// </summary>
[Serializable]
public class EnemyState
{
    public int id = 0;
    public int currentHealth = 0;
    public float x = 0, y = 0, z = 0;

    public EnemyState(Enemy controller = null)
    {

        id = controller.GetInstanceID();
        currentHealth = controller.stats.currentHealth;
        x = controller.transform.position.x;
        y = controller.transform.position.y;
        z = controller.transform.position.z;
    }
}