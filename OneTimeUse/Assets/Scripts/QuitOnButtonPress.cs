using UnityEngine;
using UnityEngine.InputSystem;

public class QuitOnButtonPress : MonoBehaviour
{
    public InputActionReference quitAction;

    private void Start()
    {
        quitAction.action.performed += QuitApp;
    }

    private void OnDestroy()
    {
        quitAction.action.performed -= QuitApp;
    }

    void QuitApp(InputAction.CallbackContext ctx)
    {
        /* DO NOT USE, it breaks the XROrigin :(
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
#else
         Application.Quit();
#endif
        */
    }
}
