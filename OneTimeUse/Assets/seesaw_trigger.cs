using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;

public class seesaw_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter()
    {

        GameObject obj = GameObject.Find("/Solution Sockets/Toilet Paper");

        //Disable the socket
        XRSocketInteractor socket = obj.GetComponent<XRSocketInteractor>();

        socket.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
