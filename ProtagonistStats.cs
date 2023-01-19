using System;

/// <summary>
/// Hold the players statistics.
/// </summary>
[Serializable]
public class ProtagonistStats
{
    public int currentHealth;
    public int maximumHealth;
    public float moveSpeed;

    public void ChangeHealth(int health)
    {
        currentHealth = Math.Clamp(health, 0, maximumHealth);
    }

    public void Load(int _currentHealth, int _maxHealth, float _moveSpeed)
    {
        currentHealth = _currentHealth;
        maximumHealth = _maxHealth;
        moveSpeed = _moveSpeed;
    }
}