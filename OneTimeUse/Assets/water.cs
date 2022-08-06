using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class water : MonoBehaviour
{
    ParticleSystem ps;

    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }


    void OnParticleTrigger()
    {
        var collider = ps.trigger.GetCollider(0);

        Debug.Log(collider.ToString());
        MeshRenderer mr = collider.GetComponent<MeshRenderer>();
        mr.enabled = true;
        mr.forceRenderingOff = false;

    }

}
