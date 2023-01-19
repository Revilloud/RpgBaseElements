using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.AddressableAssets;

public class LoadManager : MonoBehaviour
{
    private void Start()
    {
        // Get game state.
        var gameState = GameManager.instance.currState;
        // Load the game state.
        LoadPlayer(gameState.player);
        LoadEnemies(gameState.enemies.ToList());
        LoadItems(gameState.items.ToList());
        // Hide the loading screen.
        GameManager.instance.HideLoadingScreen();
    }

    public async void LoadPlayer(ProtagonistState _playerState)
    {
        Protagonist player = Protagonist.instance;
        // name
        player.name = _playerState.name;
        // position
        Vector3 newPosition = new Vector3(_playerState.x, _playerState.y, _playerState.z);
        player.transform.position = newPosition;
        // stats
        int health = _playerState.currentHealth;
        int maxHealth = _playerState.maxHealth;
        float moveSpeed = _playerState.moveSpeed;
        player.stats.Load(health, maxHealth, moveSpeed);
        // inventory
        List<InventorySlot> slots = new List<InventorySlot>();
        foreach(var slot in _playerState.inventoryState.slots)
        {
            Item item = await GameManager.GetItemAsync(slot.name) ?? null;
            if (item != null)
            {
                Debug.LogWarning($"Cargando a inventario: {item.name}({slot.quantity})");
                slots.Add(new InventorySlot(item, slot.quantity));
            }
        }
        player.inventory.Load(slots, _playerState.maxSlots, _playerState.maxWeight);
    }

    public void LoadEnemies(List<EnemyState> enemyStates)
    {
        if(enemyStates.Count == 0)
        {
            return;
        }

        var auxEnemyList = enemyStates;
        var enemiesInScene = FindObjectsOfType<Enemy>();
        foreach (EnemyState state in enemyStates)
        {
            
        }
        
        foreach(Enemy enemy in enemiesInScene)
        {

        }
    }

    public void LoadItems(List<ItemDropState> itemStates)
    {
        if(itemStates.Count == 0)
        {
            return;
        }
        var itemsInScene = FindObjectsOfType<ItemDrop>();
        foreach(ItemDropState state in itemStates)
        {

        }

        foreach(ItemDrop state in itemsInScene)
        {

        }
    }

    public void LoadPlayerInventory(InventoryState _inventoryState)
    {
        print(_inventoryState.maxWeight);
        print(_inventoryState.maxSlots);
        
        //var slots = GameManager.GetInventorySlots(_inventoryState.slots);
        
        //foreach(var slot in slots)
        //{
        //    print($"{slot.item.name} x{slot.quantity}");
        //}
        //}
    }
}
