using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public class Puzzle : MonoBehaviour
{
    public string puzzleName;
    private List<GameObject> puzzleObjects;
    public GameObject key;


    private enum PuzzleState { Locked, Active, Solved };
    [SerializeField] PuzzleState currentState;
    [SerializeField] PuzzleState startingState = PuzzleState.Active;

    // Optional animation to play after Puzzle has been solved
    private Animation clearedAnimation;

    [SerializeField] XRSocketInteractor socketInteractor;

    // Optional particle effect to fire off when unlocked
    public ParticleSystem playParticleOnSolved;

    // Toggle if key should be deleted on solve
    public bool destroyKeyOnSolve = true;

    // Start is called before the first frame update
    void Start()
    {
        if (socketInteractor == null)
        {

            Debug.Log($"Grabbing Interactor for {name}");
            socketInteractor = GetComponent<XRSocketInteractor>();
        }
    }

    public void Initialize(bool solved)
    {

        if (solved)
        {
            // Change state variable
            currentState = PuzzleState.Solved;

            // Turn off socket interactor
            socketInteractor.socketActive = false;

            // Tell Puzzle Manager I've been solved
            PuzzleManager.Instance.puzzles.Remove(this);
        }
        else
        {
            if (startingState == PuzzleState.Locked)
            {
                LockPuzzle();
                currentState = PuzzleState.Locked;
            }
            else
            {
                currentState = startingState;
            }
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
        if (TryGetComponent<UnlocksPuzzle>(out UnlocksPuzzle puzzleUnlocker))
        {
            puzzleUnlocker.UnlockConnectedPuzzle();
        }

        //check if I have an effect to play
        if (playParticleOnSolved)
        {
            Debug.Log("Playing Particle");
            playParticleOnSolved.Play();
        }
    }

    public void CheckStoredObject(SelectEnterEventArgs selectionInfo)
    {
        GameObject collidedObject = selectionInfo.interactableObject.transform.gameObject;
        //Debug.Log($"Comparing {collidedObject} to {key}");

        if (collidedObject.Equals(key)) 
        {
            SetSolved();

            if (destroyKeyOnSolve)
            {
                Destroy(collidedObject);
            }            
        }
    }

    public bool GetClearedState()
    {
        return (currentState == PuzzleState.Solved);
    }

    public bool GetLockedState()
    {
        return (currentState == PuzzleState.Locked);
    }
}
