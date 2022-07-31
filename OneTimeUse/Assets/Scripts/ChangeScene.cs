using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    private int sceneToLoad;

    public void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }

    public void SetScene(int whichScene)
    {
        sceneToLoad = whichScene;
    }
}
