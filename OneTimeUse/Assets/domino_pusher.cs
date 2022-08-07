using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class domino_pusher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {

        GameObject obj = GameObject.Find("/Dominoes/Domino (5)");
        obj.GetComponent<Rigidbody>().velocity = new Vector3(0.75f, 0f, -2.7f);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
