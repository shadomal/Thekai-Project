using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        jumpForce = 40;
        
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

    #region Colliders

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            OnGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            OnGround = false;
        }
    }

    #endregion

    #region VIDA

    public int life_;
    public int maxLife_;
    public Image lifeBar;

    public int GetLife() => life_;
    public void SetLife(int increment)
    {
        if (increment >= life_)
        {
            life_ = maxLife_;
        }
        else
        {
            life_ = increment;
        }
        UpdateLifeBar();
        if (life_ <= 0)
        {
            DeathController();
        }
    }
    public void AddHealth(int lifeIncrement) => this.SetLife(life_ + lifeIncrement);
    public void RemoveHealth(int lifeReduced) => this.SetLife(life_ - lifeReduced);
    public void UpdateLifeBar() => this.lifeBar.fillAmount = ((1.6f / this.maxLife_) * life_);
    public void DeathController()
    {
        Destroy(gameObject);
    }

    #endregion
    

}
