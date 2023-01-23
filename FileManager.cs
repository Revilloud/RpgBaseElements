using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class FileManager
{
    public static void InitializeSaveDirectory()
    {
        // Create the save directory if it doesn't exist.
        string filePath = Application.persistentDataPath + "/saves";

        if (Directory.Exists(filePath))
        {
            Debug.Log("Saved files directory found.");
            return;
        }
        Debug.Log("Saves directory doesn't exist. Creating one.");
        Directory.CreateDirectory(filePath);
    }
    public static void SaveGame(string jsonContent, string fileName)
    {
        // Turn game data to text on a json file and write to disk
        string filePath = $"{Application.persistentDataPath}/saves/{fileName}.json";
        File.WriteAllText(filePath, jsonContent);
    }
    public static List<GameState> GetExistingGames()
    {
        // Explore the save file directory for save files.
        string filePath = $"{Application.persistentDataPath}/saves";
        var files = Directory.GetFiles(filePath);
        List<GameState> result = new List<GameState>();

        // No saves found.
        if (files.Length == 0)
        {
            Debug.Log("No saves games found.");
            return result;
        }

        Debug.Log($"{files.Length} save games found.");
        // Save file to game state conversion
        foreach (var file in files)
        {
            string content = File.ReadAllText(file);
            var gameState = JsonUtility.FromJson<GameState>(content);
            result.Add(gameState);
        }
        return result;
    }
}
