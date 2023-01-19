using System;
using UnityEngine;
/// <summary>
/// Reduces a percentage damage type's damage value.
/// </summary>
[Serializable]
public struct Defence
{
    /// <summary>
    /// Damage type to be reduced.
    /// </summary>
    [Tooltip("Damage type to be reduced.")]
    public DamageType defendsAgainst;
    /// <summary>
    /// How much is the damage is reduced. 1 is 100% reduction.
    /// </summary>
    [Range(-1,1), Tooltip("Negative range will increase the damage received, 0 will not change the value, and positive values reduce the incoming damage up to 100%")]
    public float reducedValue;
}