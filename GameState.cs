using System;

[Serializable]
public class GameState
{
    public string creationTime;
    public string updateTime;
    public ProtagonistState player;
    public EnemyState[] enemies;
    public ItemDropState[] items;
}