using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

[ExecuteInEditMode]
public class water_top2 : MonoBehaviour
{
    List<int> total_entered = new List<int>();
    int num_colliders = 0;
    ParticleSystem ps;
    bool triggered = false;
    GameObject obj;
    Animation anim;

    void Start()
    {
        obj = GameObject.Find("/Solution Sockets/Solo Cup");

        anim = obj.GetComponent<Animation>();
    }


    void OnParticleTrigger()
    {

        for (int i = 0; i < num_colliders; i++)
        {
            ps = GetComponent<ParticleSystem>();

            List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

            //get the collider 
            var collider = ps.trigger.GetCollider(i);

            //check to see if there are particles in collider

            //This is the problem line, GetTriggerParticles gets all particles across all colliders
            int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);


            if (numEnter > 0)
            {
                total_entered[i] += numEnter;
            }

            if (total_entered[i] > 15 && !triggered)
            {
                Debug.Log("One");
                MeshRenderer mr = collider.GetComponent<MeshRenderer>();
                mr.enabled = true;
                mr.forceRenderingOff = false;

                Debug.Log("Post");
                obj = GameObject.Find("/Solution Sockets/Solo Cup");

                anim = obj.GetComponent<Animation>();
                Behaviour bhvr = (Behaviour)anim;
           
                bhvr.enabled = true;

            }

        }

    }



}
