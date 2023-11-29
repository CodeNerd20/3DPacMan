using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControls : MonoBehaviour
{
    private Rigidbody blinkyRb;
    private Rigidbody inkyRb;
    private Rigidbody pinkyRb;
    private Rigidbody clydeRb;

    // Start is called before the first frame update
    void Start()
    {
        blinkyRb = GetComponent<Rigidbody>();
        inkyRb = GetComponent<Rigidbody>();
        pinkyRb = GetComponent<Rigidbody>();
        clydeRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
