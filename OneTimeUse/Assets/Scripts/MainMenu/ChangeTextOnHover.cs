using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeTextOnHover : MonoBehaviour
{
    public GameObject objectToDisplay;

    public void OnPointerEvent(BaseEventData eventData)
    {

        //Debug.Log("Pointer hovered");
        objectToDisplay.SetActive(true);
    }

    public void OnPointerExit(BaseEventData eventData)
    {
        objectToDisplay.SetActive(false);
    }

    public void ShowSelected()
    {
        objectToDisplay.SetActive(true);
    }

    public void HideSelected()
    {
        objectToDisplay.SetActive(false);
    }
}
