using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkyControls : MonoBehaviour
{
    public float moveSpeed = 17.5f;
    public float turnSpeed = 180f;
    public float changeDirectionInterval = 2f; // Time interval to change direction

    private Transform pinkyTransform;

    public Vector3 randomDirection;

    void Start()
    {
        pinkyTransform = transform;
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
        pinkyTransform.Translate(randomDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("pinky Collided with Wall");
            Vector3 normal = collision.contacts[0].normal;
            Vector3 adjustment = normal * 2f;
            transform.position += adjustment;
        }
    }
}
