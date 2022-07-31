using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public class Puzzle : MonoBehaviour
{
    private List<GameObject> puzzleObjects;
    public GameObject key;

    private enum PuzzleState { Locked, Active, Solved };
    [SerializeField] PuzzleState currentState;
    [SerializeField] PuzzleState startingState = PuzzleState.Active;

    // Optional animation to play after Puzzle has been solved
    private Animation clearedAnimation;

    [SerializeField] XRSocketInteractor socketInteractor;

    // Start is called before the first frame update
    void Start()
    {
        // Add self to Puzzle Manager
        Debug.Log($"Adding self {gameObject.name} to Puzzle Manager");
        PuzzleManager.Instance.puzzles.Add(this);

        if (socketInteractor == null)
        {
            socketInteractor = GetComponent<XRSocketInteractor>();
        }

        currentState = startingState;

        if (currentState == PuzzleState.Locked)
        {
            LockPuzzle();
        }
        
    }

    public void UnlockPuzzle()
    {
        this.currentState = PuzzleState.Active;
        socketInteractor.socketActive = true;
    }

    public void LockPuzzle()
    {
        this.currentState = PuzzleState.Locked;
        socketInteractor.socketActive = false;
    }

    private void ResetObjects()
    {
        foreach(GameObject go in puzzleObjects)
        {
            go.GetComponent<PuzzleObject>().Reset();
        }
    }

    public void SetSolved()
    {
        // Change state variable
        currentState = PuzzleState.Solved;

        // Turn off socket interactor
        socketInteractor.socketActive = false;

        // Tell Puzzle Manager I've been solved
        PuzzleManager.Instance.PuzzleCleared(this);

        // Check if I unlock any puzzles
        if(TryGetComponent<UnlocksPuzzle>(out UnlocksPuzzle puzzleUnlocker))
        {
            puzzleUnlocker.UnlockConnectedPuzzle();
        }
    }

    public void CheckStoredObject(SelectEnterEventArgs selectionInfo)
    {
        GameObject collidedObject = selectionInfo.interactableObject.transform.gameObject;
        //Debug.Log($"Comparing {collidedObject} to {key}");

        if (collidedObject.Equals(key)) 
        {
            //Debug.Log($"Key inserted");
            SetSolved();

            Destroy(collidedObject);
        }
    }
}
