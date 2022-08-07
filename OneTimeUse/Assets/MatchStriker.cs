using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStriker : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        //check if the collider is tagged as "Player" this time.
        if (other.tag == "Match")
        {
            ParticleSystem ps = other.transform.GetChild(2).GetComponent<ParticleSystem>();
            ps.Play();
            ps = other.transform.GetChild(3).GetComponent<ParticleSystem>();
            ps.Play();
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
