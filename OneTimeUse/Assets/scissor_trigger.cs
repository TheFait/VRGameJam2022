using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scissor_trigger : MonoBehaviour
{
    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (!flag)
        {
            Debug.Log("Collide!");
            GameObject obj = GameObject.Find("/scissor blades/Blade");

            Animation anim = obj.GetComponent<Animation>();
            Behaviour bhvr = (Behaviour)anim;

            bhvr.enabled = true;

            anim.Play("scissor");

            obj = GameObject.Find("/Bowling ball/Sphere");
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
            rb.mass = 5;
            flag = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
