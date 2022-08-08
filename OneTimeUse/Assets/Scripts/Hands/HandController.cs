using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class HandController : MonoBehaviour
{
    public ActionBasedController controller;
    public Hand hand;

    // Start is called before the first frame update
    void Start()
    {
        if(controller == null)
        {
            controller = GetComponent<ActionBasedController>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //get inputs
        hand.SetGrip(controller.selectAction.action.ReadValue<float>());
        hand.SetTrigger(controller.activateAction.action.ReadValue<float>());
    }
}
