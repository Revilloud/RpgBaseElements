using System;
using UnityEngine;

/// <summary>
/// Unit of damage dealt to a character when struck by an attack.
/// </summary>
[Serializable]
public struct Damage
{
    private DamageType damageType;
    private int minDamage;
    private int maxDamage;

    public DamageType Type => damageType;
    public int DamageAmmount => UnityEngine.Random.Range(minDamage, maxDamage);
}