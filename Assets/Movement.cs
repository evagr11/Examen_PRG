using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float acceleration;
    [SerializeField] float maxSpeed;
    [SerializeField] float fricion;

    private bool accelerating;
    private bool deccelerating;
    private float horizontalInput;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        MovementPhysics();
    }

    void ProcessInput()
    {
        horizontalInput = 0;

        accelerating = Input.GetKey(KeyCode.W);

        deccelerating = Input.GetKey(KeyCode.S);

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }
    }

    void MovementPhysics()
    {
        Vector3 localVelocity = transform.InverseTransformDirection(new Vector3(rb.velocity.x, rb.velocity.y, 0));
        float forwrdSpeed = localVelocity.y;


        if (accelerating)
        {
            if (forwrdSpeed < maxSpeed)
            {
                rb.velocity += (Vector2)(speed * transform.up * Time.fixedDeltaTime);
            }
        }
        else
        {
            rb.velocity *= (1 / (1 + fricion * Time.fixedDeltaTime));
        }

        if(deccelerating)
        {
            rb.velocity -= (Vector2)(speed * transform.up * Time.fixedDeltaTime);
        }

        if(horizontalInput != 0)
        {
            rb.velocity += Vector2.right * horizontalInput * speed * Time.fixedDeltaTime;
        }
    }

}
