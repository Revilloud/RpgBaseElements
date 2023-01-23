using UnityEngine;

/// <summary>
/// Enemy starting stats template.
/// </summary>

[CreateAssetMenu(fileName = "new enemy", menuName = "New/Enemy")]
public class EnemyData : ScriptableObject
{
    public int maxHealth;
    public float moveSpeed;
    public EnemyItem[] items;
}