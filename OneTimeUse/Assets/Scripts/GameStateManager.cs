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
        public List<Checkpoint> checkpoints;

        public GameData()
        {
            checkpoints = new List<Checkpoint>();
        }
    }

    [Serializable]
    public class Checkpoint
    {
        public string name;
        public bool cleared;
        public bool locked;

        public Checkpoint(string name, bool cleared, bool locked)
        {
            this.name = name;
            this.cleared = cleared;
            this.locked = locked;
        }
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

    private string filePath;
    private void Start()
    {
        // build filepath from Streaming Assets Folder
        filePath = Path.Combine(Application.streamingAssetsPath, "GameData.json");
        filePath = filePath.Replace(@"\", @"/"); // cleanup in case format is wrong

        ReadFromFile();
    }

    void ReadFromFile()
    {
        // Create the file if it doesn't exist yet
        if (!File.Exists(filePath))
        {
            // No need to create file here, it's done while writing
        }
        else // file already exists
        {
            string json = File.ReadAllText(filePath);
            Debug.Log($"Data read in: {json}");
            gameData = JsonUtility.FromJson<GameData>(json);

            // File found, tell the UI Manager we can continue a save
            MainMenuManager.Instance.SaveFileFound();
        }


    }

    void SaveToFile()
    {
        // Convert game data to JSON
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(filePath, json);
        Debug.Log($"Saved file to JSON: {json}");
    }

    public void EndGame()
    {
        ChangeScene sceneChanger = GetComponent<ChangeScene>();
        sceneChanger.SetScene(0);
        sceneChanger.LoadNewScene();
    }

    public void InitializeCheckpoint(Puzzle toCreate)
    {
        // Check if puzzle already exists in checkpoint file
        // If doesn't exist, create a checkpoint and add to file
        // If it already exists, grab the solved value and update the Puzzle
        // (Updating only required if the puzzle should already be solved)
        bool found = false;
        foreach (Checkpoint point in gameData.checkpoints)
        {
            if (point.name == toCreate.puzzleName)
            {
                found = true;
                //Debug.Log($"Puzzle {toCreate.puzzleName} found in checkpoints. Solved: {point.cleared}");

                if (point.cleared)
                {
                    // Set Puzzle to Solved State
                    toCreate.Initialize(true);
                }
                else
                {
                    // Initialize puzzle with defaults
                    toCreate.Initialize(false);

                    if (!point.locked)
                    {
                        toCreate.UnlockPuzzle();
                    }
                }
            }
        }

        if (!found)
        {

            Debug.Log($"Unable to find {toCreate.name}");
            // Initialize the puzzle with default values
            toCreate.Initialize(false);

            // Create a new checkpoint with the puzzle name and set it to unsolved
            gameData.checkpoints.Add(new Checkpoint(toCreate.puzzleName, false, toCreate.GetLockedState()));

            // Write out the updated gameData to file
            SaveToFile();
        }
    }

    public void UpdateCheckpoint(Puzzle puzzleToUpdate)
    {
        // If puzzle exists in checkpoint table, update the checkpoint with the puzzle state
        bool updated = false;

        foreach (Checkpoint point in gameData.checkpoints)
        {
            if (point.name == puzzleToUpdate.puzzleName)
            {

                //Debug.Log($"Found puzzle {puzzleToUpdate.puzzleName}, setting cleared state");
                // Puzzle found, update checkpoint with state
                point.cleared = puzzleToUpdate.GetClearedState();
                point.locked = puzzleToUpdate.GetLockedState();

                SaveToFile();

                updated = true;
            }
            
        }

        if (!updated)
        {
            Debug.Log($"Trying to update non-existant puzzle {puzzleToUpdate.puzzleName}");
        }
    }

    public void ResetGame()
    {
        // Set all cleared values in checkpoint to false
        foreach (Checkpoint point in gameData.checkpoints)
        {
            point.cleared = false;
        }
    }

    public bool directInteractor = false;
    public void SetInteractor(bool direct)
    {
        directInteractor = direct;
    }
}
