using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class water : MonoBehaviour
{
    List<int> total_entered = new List<int>();
    int num_colliders = 0;
    ParticleSystem ps;

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

            if (total_entered[i] > 15)
            {
                MeshRenderer mr = collider.GetComponent<MeshRenderer>();
                mr.enabled = true;
                mr.forceRenderingOff = false;



            }

        }

    }

}
