using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;

    public GameObject newGame, loadGame, newGameUIContent, loadGameUIContent, startGameOver;

    private string currentScene = "";

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

    public void ResetAllMaterials()
    {
        newGame.GetComponent<ChangeMenuOnSelect>().ResetMaterial();
        loadGame.GetComponent<ChangeMenuOnSelect>().ResetMaterial();
        startGameOver.GetComponent<ChangeMenuOnSelect>().ResetMaterial();
    }

    public void SaveFileFound()
    {

        Debug.Log("Save File Found");
        loadGame.SetActive(true);
        startGameOver.SetActive(true);
        newGame.SetActive(false);
    }

    public void ChangeUIScene(string whichScene)
    {
        //Deselect all
        if(whichScene == currentScene)
        {
            newGameUIContent.SetActive(false);
            loadGameUIContent.SetActive(false);
            currentScene = "";
        }
        else
        {
            currentScene = whichScene;
            switch (whichScene)
            {
                case "Load":
                    //Debug.Log($"Change menu to Load");
                    newGameUIContent.SetActive(false);
                    loadGameUIContent.SetActive(true);
                    break;
                case "New":
                    //Debug.Log($"Change menu to New");
                    newGameUIContent.SetActive(true);
                    loadGameUIContent.SetActive(false);
                    break;
            }
        }
    }

    public void SetInteractor(bool direct)
    {
        //Debug.Log($"Interactor: {direct}");
        GameStateManager.Instance.SetInteractor(direct);

        if (direct)
        {
            // set direct interactor
            transform.GetChild(1).GetChild(1).GetComponent<ChangeTextOnHover>().ShowSelected();
            transform.GetChild(1).GetChild(2).GetComponent<ChangeTextOnHover>().HideSelected();
        }
        else
        {
            // set ray interactor
            transform.GetChild(1).GetChild(1).GetComponent<ChangeTextOnHover>().HideSelected();
            transform.GetChild(1).GetChild(2).GetComponent<ChangeTextOnHover>().ShowSelected();
        }
    }
}
