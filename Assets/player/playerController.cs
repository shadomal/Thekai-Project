using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public int velocity;
    public bool OnGround;
    public Rigidbody2D rb;
    public int forceMultiply;
    public int jumpForce;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = 10;
        forceMultiply = 10;
        jumpForce = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        float MoveH = Input.GetAxis("Horizontal");
        float MoveV = Input.GetAxis("Vertical");

        Movement(MoveV, MoveH);

        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void Movement(float moveV, float moveH)
    {
        rb.velocity = transform.forward * moveV * forceMultiply + transform.right * moveH * forceMultiply;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            OnGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            OnGround = false;
        }
    }
}
