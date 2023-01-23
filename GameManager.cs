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
    [SerializeField] private GameState currentState;

    public GameState CurrentState => currentState;

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
        // Initialize a GameState.
        currentState.NewGame(playerName);
        SceneManager.LoadScene(gameSceneName);
    }
    public void Save()
    {
        Debug.Log("Saving");
        // Update the GameState with the current data.
        var protagonist = Protagonist.instance.GetState();
        var enemies = FindObjectsOfType<Enemy>().Select(x => x.State()).ToArray();
        var items = FindObjectsOfType<ItemDrop>().Select(x => x.State()).ToArray();
        currentState.Update(protagonist, enemies, items);
        // Write GameState to disk.
        FileManager.SaveGame(JsonUtility.ToJson(currentState,true), currentState.GameName);
    }
    public void Load(GameState game)
    {
        currentState = game;
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
        if(string.IsNullOrEmpty(itemName)) return null;
        var result = await Addressables.LoadAssetAsync<Item>($"Items/{itemName.ToLower()}.asset").Task;
        return result;
    }
    public static async Task<GameObject> GetReferenceGameObject(AssetReference reference, Transform parent = null)
    {
        var result = await reference.InstantiateAsync(parent ?? null).Task;
        return result ?? null;
    }
}
