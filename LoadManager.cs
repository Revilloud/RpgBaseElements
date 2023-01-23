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
        var gameState = GameManager.instance.CurrentState;
        // Load the game state.
        LoadState(gameState);
        //CargarEnemigosEnEscena(partida.enemigos);
        //CargarContenedoresEnEscena(partida.contenedores);
        // Hide the loading screen.
        GameManager.instance.HideLoadingScreen();
        Destroy(this.gameObject);
    }

    public void LoadState(GameState gameState)
    {
        LoadProtagonist(gameState.Protagonist);
    }

    public void LoadProtagonist(ProtagonistState protagonist)
    {
        LoadStats(protagonist.CharacterStats, protagonist.ProtagonistStats);
        LoadInventory(protagonist.Inventory);
        LoadEquipment(protagonist.Equipment);
    }
    public async void LoadInventory(ProtagonistInventoryState state)
    {
        Protagonist protagonist = Protagonist.instance;
        // inventario
        List<ItemByQuantity> newInventory = new List<ItemByQuantity>();
        foreach (var slot in state.ItemState)
        {
            Item item = await GameManager.GetItemAsync(slot.Name) ?? null;
            if (item != null)
            {
                Debug.LogWarning($"Cargando a inventario: {item.name}({slot.Quantity})");
                newInventory.Add(new ItemByQuantity(item, slot.Quantity));
            }
        }
        protagonist.Inventory.Load(newInventory, state.MaximumWeight);
    }

    public async void LoadEquipment(ProtagonistEquipmentState equipment)
    {
        Protagonist protagonist = Protagonist.instance;
        var head = await GameManager.GetItemAsync(equipment.Head) as Armor ?? null;
        var chest = await GameManager.GetItemAsync(equipment.Chest) as Armor ?? null;
        var legs = await GameManager.GetItemAsync(equipment.Legs) as Armor ?? null;
        var mainHand = await GameManager.GetItemAsync(equipment.MainHand) as Weapon ?? null;
        var offHand = await GameManager.GetItemAsync(equipment.OffHand) as Weapon ?? null;
        protagonist.Equipment.Load(head, chest, legs,mainHand,offHand);
    }

    public void LoadStats(CharacterStatsState cStats, ProtagonistStatsState pStats)
    {
        Protagonist protagonist = Protagonist.instance;
        protagonist.CStats.Load(cStats);
        protagonist.PStats.Load(pStats);
    }
    public static void LoadEnemyStates(Transform enemigosSerializados)
    {
        // failsafe
        //if (enemigosSerializados.Count == 0)
        {
            Debug.Log($"No hay enemigos que cargar.");
            return;
        }

        // lista auxiliar con los estados de los enemigos guardados.
        var enemigos = enemigosSerializados;
        foreach (var enemigo in enemigos)
        {

        }
        //var enemigosEnEscena = FindObjectsOfType<Enemigo2>();
        //foreach (var enemigo in enemigosEnEscena)
        {

        }
    }

    public void LoadContainerState(Transform contenedoresSerializados)
    {
        // failsafe
        //if (contenedoresSerializados.Count == 0)
        {
            return;
        }
        var contenedores = contenedoresSerializados;
        // encontrar y cargar datos de los contenedores serializados
        foreach (var contenedor in contenedores)
        {

        }

        //var contenedoresEnEscena = FindObjectsOfType<Contenedor>();
        //foreach (var contenedor in contenedoresEnEscena)
        {

        }
    }
}