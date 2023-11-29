using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput > 0.1f)
        {
            //direction = Vector3.right;
            transform.rotation = right;
        }
        if(horizontalInput < -0.1f)
        {
            //direction = Vector3.left;
            transform.rotation = left;
        }

        verticalInput = Input.GetAxis("Vertical");
        if(verticalInput > 0.1f)
        {
            //direction = Vector3.forward;
            transform.rotation = forward;
        }
        if(verticalInput < -0.1f)
        {
            //direction = Vector3.back;
            transform.rotation = back;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            gameOver = true;
            playerAnim.SetBool("Death", true);
        }
    }
}
