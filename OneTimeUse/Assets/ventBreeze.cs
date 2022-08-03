using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ventBreeze : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //check if the collider is tagged as "Player" this time.
        if (other.tag != "Player")
        {
            other.GetComponent<Rigidbody>().useGravity = false;

            other.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0.75f);

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
