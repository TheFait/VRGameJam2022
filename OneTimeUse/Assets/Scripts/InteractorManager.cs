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
    }

    private void OnDestroy()
    {
        toggleInteractorAction.action.performed -= swapInputs;
    }

    void swapInputs(InputAction.CallbackContext ctx)
    {
        //Debug.Log($"Input received");
        if (isDirect)
        {
            leftHandDirect.SetActive(false);            
            rightHandDirect.SetActive(false);
            leftHandRay.SetActive(true);
            rightHandRay.SetActive(true);

            isDirect = false;
        }
        else
        {
            leftHandRay.SetActive(false);
            rightHandRay.SetActive(false);
            leftHandDirect.SetActive(true);            
            rightHandDirect.SetActive(true);

            isDirect = true;
        }
        
    }
}
