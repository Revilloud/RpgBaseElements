using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "weapon", menuName = "new/weapon")]
public class NewWeapon : Item
{
    [Header("Weapon properties"), Space()]
    public Damage[] damagesOnHit;
}