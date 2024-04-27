using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed;
    public Vector3 jumpForce = new Vector3( 0.0f, 2.0f, 0.0f );
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x = -1.0f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDir.y = 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir.y = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir.x = 1.0f;
        }
        Vector3 movement = transform.forward * moveDir.y + transform.right * moveDir.x;
        moveDir = moveDir * speed * Time.deltaTime;

        transform.Translate(moveDir);

        Jump();
    }
}

/*Vector3 position = transform.position;
      position.x = position.x + speed * Time.deltaTime;
      transform.position = position;*/