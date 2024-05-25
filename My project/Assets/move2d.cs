using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2d : MonoBehaviour
{
    public float acceleration = 1.0f;
    public float jumpForce = 10.0f;
    
    private Rigidbody2D rb = null;
    private bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    bool isGrounded()
    {
        int layerMask = LayerMask.GetMask("Ground");
        Vector2 offset = new Vector2(0.0f, 0.0f);
        Vector2 position = new Vector2(transform.position.x, 
            transform.position.y);
        return Physics2D.Raycast(position + offset,
          Vector2.down, 0.6f, layerMask);
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
    }
    void FixedUpdate()
    {
        float mass = rb.mass;
        if(Input.GetKey(KeyCode.A))
        {
            Vector2 movement = new Vector2(-acceleration * mass, 0.0f);
            rb.AddForce(movement, ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            Vector2 movement = new Vector2(acceleration * mass, 0.0f);
            rb.AddForce(movement, ForceMode2D.Force);
        }

        if (isJumping && isGrounded()) 
        {
            isJumping = false;
            rb.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
