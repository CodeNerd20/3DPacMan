using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Animator playerAnim;
    private bool gameOver = false;
    public Vector3 direction = Vector3.forward;

    public float horizontalInput;
    public float verticalInput;

    private Quaternion forward = Quaternion.identity;
    private Quaternion back = Quaternion.Euler(0, 180, 0);
    private Quaternion left = Quaternion.Euler(0, -90, 0);
    private Quaternion right = Quaternion.Euler(0, 90, 0);

    public GameManager gameManager;

    public bool hasPowerUp;
    public int value;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        gameManager =GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(direction * speed * Time.deltaTime);

            horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput > 0.1f)
            {
                //direction = Vector3.right;
                transform.rotation = right;
            }
            if (horizontalInput < -0.1f)
            {
                //direction = Vector3.left;
                transform.rotation = left;
            }

            verticalInput = Input.GetAxis("Vertical");
            if (verticalInput > 0.1f)
            {
                //direction = Vector3.forward;
                transform.rotation = forward;
            }
            if (verticalInput < -0.1f)
            {
                //direction = Vector3.back;
                transform.rotation = back;
            }

            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            Debug.Log("Pac-Man Died");
            gameOver = true;
            playerAnim.SetBool("Death", true);
            gameManager.GameOver();
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Collided with Wall");
            Vector3 normal = collision.contacts[0].normal;
            // Calculate a position adjustment vector
            Vector3 adjustment = normal * 2f;

            // Move Pac-Man to a new position just outside the wall
            transform.position += adjustment;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Debug.Log("Got Power-Up");
            hasPowerUp = true;
            Destroy(other.gameObject);
            gameManager.UpdateScore(value);
            gameManager.ScareGhosts();
        }
    }
}  

