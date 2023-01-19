using System;
using UnityEngine;

/// <summary>
/// Enemy item drop. Which item will be dropped, how many of it, and what are the chances of getting it.
/// </summary>
[Serializable]
public struct EnemyItem
{
    public Item item;
    public int minimumQuanity;
    public int maximumQuanity;
    public float changeToGet;
}