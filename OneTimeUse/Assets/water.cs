using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class water : MonoBehaviour
{
    List<int> total_entered = new List<int>();
    int num_colliders = 0;
    ParticleSystem ps;
    bool flag = false;
    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
        num_colliders = ps.trigger.colliderCount;
        for(int i = 0; i < num_colliders; i++)
        {
            total_entered.Add(0);
        }
    }


    void OnParticleTrigger()
    {

        for (int i = 0; i < num_colliders; i++)
        {
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

            if (total_entered[i] > 15 && !flag)
            {
                MeshRenderer mr = collider.GetComponent<MeshRenderer>();
                mr.enabled = true;
                mr.forceRenderingOff = false;

                GameObject obj = GameObject.Find("/Solution Sockets/Solo Cup");

                Animation anim = obj.GetComponent<Animation>();
                Behaviour bhvr = (Behaviour)anim;

                bhvr.enabled = true;

                anim.Play("Solocup");
                flag = true;
            }

        }

    }

}
