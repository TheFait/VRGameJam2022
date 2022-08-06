using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyPopper : MonoBehaviour
{
    public ParticleSystem launchParticle;
    public GameObject popperCap;

    public GameObject teabag;

    private bool launched = false;

    public Transform landingDestination;

    public float timeToReachDestination;

    private Rigidbody teabagRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        teabagRigidBody = teabag.GetComponent<Rigidbody>();
        Debug.Log($"Party Popper enabled");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch()
    {
        if (!launched)
        {
            // Remove front collision
            popperCap.SetActive(false);

            Debug.Log("Launching!");


            // Play launch particle effect
            launchParticle.Play();


            //Calculate trajectory for teabag

            // Launch teabag
            
            teabagRigidBody.isKinematic = false;
            teabagRigidBody.AddForce(CalculateTrajectoryVelocity(teabag.transform.position, landingDestination.position, timeToReachDestination), ForceMode.VelocityChange);
            teabagRigidBody.detectCollisions = false;

            StartCoroutine(teabagCollisionDelay());

            launched = true;

            // Interpolate position between teabag and destination
            
        }
        else
        {

            Debug.Log("Already launched!");
        }
        
    }

    IEnumerator teabagCollisionDelay()
    {
        yield return new WaitForSeconds(timeToReachDestination/2);

        teabagRigidBody.detectCollisions = true;
    }

    private Vector3 CalculateTrajectoryVelocity(Vector3 origin, Vector3 target, float t)
    {
        float vx = (target.x - origin.x) / t;
        float vz = (target.z - origin.z) / t;
        float vy = ((target.y - origin.y) - 0.5f * Physics.gravity.y * t * t) / t;
        return new Vector3(vx, vy, vz);
    }
}
