using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public List<Puzzle> puzzles = new List<Puzzle>();



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
        //Debug.Log($"Removing {clearedPuzzle.name} from list");

        // remove puzzle from puzzle list
        puzzles.Remove(clearedPuzzle);

        // Check if game is won
        CheckWin();
    }
}
