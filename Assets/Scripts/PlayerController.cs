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

    private float horizontalInput;
    

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
        if(horizontalInput == 1)
        {
            direction = Vector3.right;
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
