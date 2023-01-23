using System;
using UnityEngine;

[Serializable]
// Valores fundamentales que representan el estado del una partida en un momento determinado.
// 👍
public class GameState
{
    [SerializeField] private string creationTime;
    [SerializeField] private string updateTime;
    [SerializeField] private ProtagonistState protagonist;
    [SerializeField] private EnemyState[] enemies;
    [SerializeField] private ItemDropState[] items;
    public string GameName => protagonist.ProtagonistStats.Name;
    public string CreationTime => creationTime;
    public string UpdateTime => updateTime;
    public ProtagonistState Protagonist => protagonist;
    public EnemyState[] Enemies => enemies;
    public ItemDropState[] Items => items;
    
    public void NewGame(string playerName)
    {
        this.protagonist.ProtagonistStats.SetName(playerName);
        string currTime = DateTime.Now.ToString("g");
        this.creationTime = currTime;
        this.updateTime = currTime;
    }

    public void Update(ProtagonistState protagonist, EnemyState[] enemies, ItemDropState[] items)
    {
        this.updateTime = DateTime.Now.ToString("g");
        this.protagonist = protagonist;
        this.enemies = enemies;
        this.items = items;
    }
}