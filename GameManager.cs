using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game Settings"), Space()]
    public string gameSceneName = "GameScene";

    [Header("Loading Screen"), Space()]
    
    public GameObject loadingRenderer;
    public List<Sprite> loadingImages;

    [Header("Current Game"), Space()]
    public bool newGame;
    public GameState currState;
    public string newName;

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnEnable()
    {
        instance = this;
    }
    private void Start()
    {
        newGame = false;
        HideLoadingScreen();
    }
    public void New(string playerName)
    {
        // Set flag to start a new game when the game scene loads.
        newGame = true;
        newName = playerName;

        // Initialize a GameState.
        GameState gameState = currState;
        string currTime = DateTime.Now.ToString("g");
        gameState.creationTime = currTime;
        gameState.updateTime = currTime;
        gameState.player.name = playerName;
        currState = gameState;
        SceneManager.LoadScene(gameSceneName);
    }
    public void Save()
    {
        Debug.Log("Saving");
        // Update the GameState with the current data.
        currState.updateTime = DateTime.Now.ToString("g");
        currState.player = FindObjectOfType<Protagonist>().GetState();
        var enemies = FindObjectsOfType<Enemy>().Select(x => x.GetState()).ToArray();
        currState.enemies = enemies;
        var items = FindObjectsOfType<ItemDrop>().Select(x => x.GetState()).ToArray();
        currState.items = items;
        
        // Write GameState to disk.
        FileManager.SaveGame(currState);
    }
    public void Load(GameState game)
    {
        currState = game;
        ShowLoadingScreen(GetRandomLoadingImage());
        SceneManager.LoadScene(gameSceneName);
    }
    public void Delete(string gameName)
    {

    }
    private void ShowLoadingScreen(Sprite _sprite = null)
    {
        if(_sprite != null)
        {
            loadingRenderer.GetComponentInChildren<Image>().sprite = _sprite;
        }
        loadingRenderer.SetActive(true);
    }
    private Sprite GetRandomLoadingImage()
    {
        Sprite sprite = null;
        if (loadingImages.Count > 0)
        {
            Sprite loadingImage = loadingImages[UnityEngine.Random.Range(0, loadingImages.Count)];
            sprite = loadingImage;
        }
        return sprite;
    }
    public void HideLoadingScreen()
    {
        if(loadingRenderer != null)
            loadingRenderer.SetActive(false);
    }
    public static async Task<Item> GetItemAsync(string itemName)
    {
        var result = await Addressables.LoadAssetAsync<Item>($"Items/{itemName.ToLower()}.asset").Task;
        return result ?? null;
    }

    /*
    public static List<InventorySlot> GetInventorySlots(InventorySlotState[] _slots)
    {
        Debug.Log("Load player inventory...");

        // Find every inventory item in the item database.
        IList<Task<Item>> handles= new List<Task<Item>>();
        foreach(InventorySlotState _slot in _slots)
        {
            handles.Add(Addressables.LoadAssetAsync<Item>($"Items/{_slot.name}.asset").Task);
        }

        // Error handling
        if(handles.Count != _slots.Length)
        {
            Debug.Log($"Error loading the player inventory.");
            return null;
        }

        // Wait until every item has been fetched.
        var assets = Task.WhenAll(handles);
        assets.Wait();
        var result = new List<InventorySlot>();
        if(assets.Status == TaskStatus.RanToCompletion)
        {
            for (int i = 0; i < assets.Result.Length; i++)
            {
                //result.Add(new InventorySlot(assets[i], _slots[i].quantity));
                Debug.Log($"{assets.Result[i]} x{_slots[i].quantity}");
                //Protagonist.instance.inventory.AddItem(assets.Result[i], _slots[i].quantity);
            }
            return result;
        }

        if(assets.Status == TaskStatus.Faulted)
        {
            Debug.Log("ugh");
            return null;
        }

        return null;
    }
    public async Task GetItems(InventorySlotState[] _slots)
    {
        IList<string> addresses = new List<string>();
        foreach(InventorySlotState slot in _slots)
        {
            addresses.Add($"Items/{slot.name}.asset");
        }
        var uh = await Addressables.LoadAssetsAsync<Item>(addresses, null,Addressables.MergeMode.Union).Task;
        for(int i = 0; i < uh?.Count; i++)
        {
            Debug.Log($"{uh[i].name}");
        }
    }

    // Find an item in the item database and adds it to the player inventory.
    private IEnumerator AddItemToInventoryByAddress(string _address, int _quantity)
    {
        // Retrieve asset from memory.
        AsyncOperationHandle<Item> handle = Addressables.LoadAssetAsync<Item>($"Items/{_address}.asset");

        // Once item has been retrieved, add it to the player inventory.
        handle.Completed += obj =>
        {
            Item i = obj.Result;
            Debug.Log($"[{i.name} (x{_quantity})] loaded.");
            Protagonist.instance.inventory.AddItem(i, _quantity);
        };
        yield return null;
    }
    */
}
