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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sockets")
        {
            GameObject obj = GameObject.Find("/Solution Sockets/Toilet Paper");

            //Disable the socket
            XRSocketInteractor socket = obj.GetComponent<XRSocketInteractor>();

            socket.enabled = false;

            //Traj animation
            obj = GameObject.Find("/toilet paper");
            Animation anim = obj.GetComponent<Animation>();
            anim.Play("toiletpaper");



        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
