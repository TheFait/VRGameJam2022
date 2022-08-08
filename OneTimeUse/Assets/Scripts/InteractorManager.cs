using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractorManager : MonoBehaviour
{
    public static InteractorManager Instance;

    public InputActionReference toggleInteractorAction;

    public GameObject leftHandRay, leftHandDirect, rightHandRay, rightHandDirect;

    private bool isDirect = false;


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
        toggleInteractorAction.action.performed += swapInputs;


        //Debug.Log($"Loading with interactor: {GameStateManager.Instance.directInteractor}");

        /*
        isDirect = GameStateManager.Instance.directInteractor;
        */
        isDirect = true;

        SetInput();
    }

    private void OnDestroy()
    {
        toggleInteractorAction.action.performed -= swapInputs;
    }

    void swapInputs(InputAction.CallbackContext ctx)
    {
        //Debug.Log($"Input received");
        isDirect = !isDirect;
        SetInput();
        
    }

    void SetInput()
    {
        if (!isDirect)
        {
            leftHandDirect.SetActive(false);
            rightHandDirect.SetActive(false);
            leftHandRay.SetActive(true);
            rightHandRay.SetActive(true);
        }
        else
        {
            leftHandRay.SetActive(false);
            rightHandRay.SetActive(false);
            leftHandDirect.SetActive(true);
            rightHandDirect.SetActive(true);
        }
    }
}
