using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;

    public GameObject newGame, loadGame, newGameUIContent, loadGameUIContent;

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
    }

    public void ChangeUIScene(string whichScene)
    {
        switch (whichScene)
        {
            case "Load":
                Debug.Log($"Change menu to Load");
                newGameUIContent.SetActive(false);
                loadGameUIContent.SetActive(true);
                break;
            case "New":
                Debug.Log($"Change menu to New");
                newGameUIContent.SetActive(true);
                loadGameUIContent.SetActive(false);
                break;
        }
    }
}
