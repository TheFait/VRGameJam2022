using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeMenuOnSelect : MonoBehaviour
{
    public Material onSelectMaterial;
    public string menuState;

    private Material baseMat;

    bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        baseMat = GetComponentInChildren<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelected(SelectEnterEventArgs selectEnterEventArgs)
    {
        

        if (!selected)
        {
            // Reset all materials
            MainMenuManager.Instance.ResetAllMaterials();

            // loop through children and change all materials to the new one
            Renderer[] children = GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children)
            {
                rend.material = onSelectMaterial;
            }

            selected = true;
        }
        else
        {
            ResetMaterial();
        }
        

        // Change UI to the Selected Scene
        MainMenuManager.Instance.ChangeUIScene(menuState);
    }

    public void ResetMaterial()
    {
        Renderer[] children = GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in children)
        {
            rend.material = baseMat;
        }

        selected = false;
    }

    public void OnActivate(ActivateEventArgs selectEnterEventArgs)
    {


        if (!selected)
        {
            // Reset all materials
            MainMenuManager.Instance.ResetAllMaterials();

            // loop through children and change all materials to the new one
            Renderer[] children = GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children)
            {
                rend.material = onSelectMaterial;
            }

            selected = true;
        }
        else
        {
            ResetMaterial();
        }


        // Change UI to the Selected Scene
        MainMenuManager.Instance.ChangeUIScene(menuState);
    }
}
