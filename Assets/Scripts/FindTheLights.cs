using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTheLights : MonoBehaviour
{
    public Light[] lights;
    // Start is called before the first frame update
    void Start()
    {
        lights = GameObject.FindObjectsOfType<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
