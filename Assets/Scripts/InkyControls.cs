using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkyControls : MonoBehaviour
{
    public float moveSpeed = 17.5f;
    public float turnSpeed = 180f;
    public float changeDirectionInterval = 2f; // Time interval to change direction

    private Transform inkyTransform;

    public Vector3 randomDirection;

    [Header("OMG I SCARED")]
    public GameObject normalModel;
    public GameObject scaredModel;
    public float scaredTime;

    void Start()
    {
        inkyTransform = transform;
        StartCoroutine(RandomMovement());
        StopBeingAWussy();
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

    private void FixedUpdate()
    {
        // Move the character in the random direction
        inkyTransform.Translate(randomDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("inky Collided with Wall");
            Vector3 normal = collision.contacts[0].normal;
            Vector3 adjustment = normal * 2f;
            transform.position += adjustment;
        }
    }

    public void GetScared()
    {
        normalModel.SetActive(false);
        scaredModel.SetActive(true);
    }

    public void StopBeingAWussy()
    {
        scaredModel.SetActive(false);
        normalModel.SetActive(true);
        StartCoroutine(ScaredTime());
    }

    IEnumerator ScaredTime()
    {
        yield return new WaitForSeconds(scaredTime);
        StopBeingAWussy();
    }
}
