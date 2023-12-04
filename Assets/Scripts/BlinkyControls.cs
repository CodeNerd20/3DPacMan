using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkyControls : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float changeDirectionInterval = 2f; // Time interval to change direction

    private Transform blinkyTransform;

    public Vector3 randomDirection;

    void Start()
    {
        blinkyTransform = transform;
        StartCoroutine(RandomMovement());
    }

    IEnumerator RandomMovement()
    {
        while (true)
        {
            // Generate random direction
            randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

         

            // Wait for a certain amount of time before changing direction
            yield return new WaitForSeconds(changeDirectionInterval);
        }
    }

    private void Update()
    {
        // Move the character in the random direction
        blinkyTransform.Translate(randomDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
