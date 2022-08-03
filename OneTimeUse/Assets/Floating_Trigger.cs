using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating_Trigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //check if the collider is tagged as "Player" this time.
        if (other.tag != "Player")
        {
            other.GetComponent<Rigidbody>().useGravity = false;

            other.GetComponent<Rigidbody>().velocity = new Vector3(0, 0.5f, 0f);

        }
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
