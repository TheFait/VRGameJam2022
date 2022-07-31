using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    // Class to hold the data for the game
    [Serializable]
    public class GameData
    {
        public List<Checkpoint> checkpoints = new List<Checkpoint>();
    }

    [Serializable]
    public class Checkpoint
    {
        public string name;
        public bool cleared;
    }

    public GameData gameData = new GameData();

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        ReadFromFile();
    }

    void ReadFromFile()
    {
        // build filepath from Streaming Assets Folder
        string filePath = Path.Combine(Application.streamingAssetsPath, "GameData.json");
        filePath = filePath.Replace(@"\", @"/"); // cleanup in case format is wrong

        // Create the file if it doesn't exist yet
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }
        else // file already exists
        {
            string json = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(json);
        }


    }

    public void EndGame()
    {
        ChangeScene sceneChanger = GetComponent<ChangeScene>();
        sceneChanger.SetScene(0);
        sceneChanger.LoadNewScene();
    }
}
