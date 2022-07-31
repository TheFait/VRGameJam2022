using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    private Transform startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        // reset transform to start
        transform.position = startingPosition.position;
        transform.rotation = startingPosition.rotation;
    }
}
