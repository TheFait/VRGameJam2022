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

    void OnEnable()
    {

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

                //TODO
                var socket= gameObject.transform.Find("/Solution Sockets/Solo Cup");
                //Disable Cup's socket, which add to the weight of the platform rigidbody from the cup

                socket.transform.Translate(Vector3.down);

            }

        }

    }

}
