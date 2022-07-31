using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShrinkOnStore : MonoBehaviour
{
    XRSocketInteractor socket;

    [SerializeField] float shrinkScale = .1f;
    Vector3 oldScale;

    // Start is called before the first frame update
    void Start()
    {
        //Grab Socket Interactor
        socket = GetComponent<XRSocketInteractor>();

    }

    private SelectEnterEvent ShrinkObject()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShrinkHeldObject(SelectEnterEventArgs selectionInfo)
    {
        oldScale = selectionInfo.interactableObject.transform.localScale;
        selectionInfo.interactableObject.transform.localScale *= shrinkScale;
    }

    public void ReturnHeldObject(SelectExitEventArgs selectionInfo)
    {
        selectionInfo.interactableObject.transform.localScale = oldScale;
    }
}
