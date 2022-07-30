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
        //Debug.Log("Quitting App");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
