using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlinkyControls : MonoBehaviour
{
    public float moveSpeed = 17.5f;
    public float turnSpeed = 180f;
    public float changeDirectionInterval = 2f; // Time interval to change direction
    public Transform GhostSpawn;
    public int value;
    public GameManager gm;

    private Transform blinkyTransform;

    public Vector3 randomDirection;

    private Rigidbody blinkyrb;
    private GameObject player;

    [Header("OMG I SCARED")]
    public GameObject normalModel;
    public GameObject scaredModel;
    public float scaredTime;
    public bool isScared;

    void Start()
    {
        isScared = false;
        blinkyrb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        blinkyTransform = transform;
        StartCoroutine(RandomMovement());
        StopBeingAWussy();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    IEnumerator RandomMovement()
    {
        while (true)
        {
            // Generate random direction
            randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

            //Rotate
            transform.Rotate(randomDirection, turnSpeed);

            // Wait for a certain amount of time before changing direction
            yield return new WaitForSeconds(changeDirectionInterval);
        }
    }

    private void FixedUpdate()
    {
        // Move the character in the random direction
        blinkyTransform.Translate(randomDirection * moveSpeed * Time.deltaTime, Space.World);

        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        blinkyrb.AddForce(lookDirection * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Blinky Collided with Wall");
            Vector3 normal = collision.contacts[0].normal;
            Vector3 adjustment = normal * 2f;
            transform.position += adjustment;
        }

        if(collision.gameObject.CompareTag("Player") && isScared)
        {
            Teleport(collision.transform);
            gm.UpdateScore(value);
            Destroy(blinkyrb);
        }
    }

    private void Teleport(Transform blinky)
    {
        blinky.position = GhostSpawn.position;
    }
    
    public void GetScared()
    {
        normalModel.SetActive(false);
        scaredModel.SetActive(true);
        isScared = true;
    }

    public void StopBeingAWussy()
    {
        scaredModel.SetActive(false);
        normalModel.SetActive(true);
        StartCoroutine(ScaredTime());
        isScared = false;
    }
    IEnumerator ScaredTime()
    {
        yield return new WaitForSeconds(scaredTime);
        StopBeingAWussy();
    }
  
}
