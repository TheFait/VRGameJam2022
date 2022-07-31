using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlocksPuzzle : MonoBehaviour
{

    public Puzzle puzzleToUnlock;

    public void UnlockConnectedPuzzle()
    {
        puzzleToUnlock.UnlockPuzzle();
    }
}
