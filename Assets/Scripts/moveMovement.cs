using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMovement : MonoBehaviour
{
    public float Speed;
    public GameObject door;
    private float Move;
    float jumpForce = 350f;
    public bool isGrounded;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y == 0)
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
        Move = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(Move * Speed, rb.velocity.y);   

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            
        }
    }

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            collision.gameObject.SetActive(false);

            door.GetComponent<BoxCollider2D>().enabled = false;
            door.gameObject.SetActive(false);
        }
    }
}
