using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{

    void OnPatrticleTrigger()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();

        Debug.Log("Oi");
        var collider = ps.trigger.GetCollider(0);

        Debug.Log(collider);

        //MeshRenderer mr = collider.transform.GetChild(0).GetComponent<MeshRenderer>();
        //mr.enabled = true;
        //mr.forceRenderingOff = false;

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
