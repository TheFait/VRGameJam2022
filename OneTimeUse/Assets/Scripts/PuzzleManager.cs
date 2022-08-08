using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public List<Puzzle> puzzles = new List<Puzzle>();


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
        // Grab all puzzles placed in the game
        Puzzle[] allPuzzles = GameObject.FindObjectsOfType<Puzzle>();

        // Initialize all puzzles
        foreach (Puzzle puzzle in allPuzzles)
        {
            InitializePuzzle(puzzle);
        }
    }


    private void CheckWin()
    {
        // Check list of remaining puzzles
        // If remaining puzzles empty, player has won
        if (puzzles.Count == 0)
        {
            Debug.Log($"Game Won");
            GameStateManager.Instance.EndGame();
        }

    }

    public void PuzzleCleared(Puzzle clearedPuzzle)
    {
        //Update GameState with cleared puzzle
        GameStateManager.Instance.UpdateCheckpoint(clearedPuzzle);

        // remove puzzle from puzzle list
        puzzles.Remove(clearedPuzzle);

        // Check if game is won
        CheckWin();
    }

    public void InitializePuzzle(Puzzle toCreate)
    {
        //Debug.Log($"Adding puzzle to list {toCreate.puzzleName}");
        puzzles.Add(toCreate);

        //GameStateManager.Instance.InitializeCheckpoint(toCreate);
    }
}
