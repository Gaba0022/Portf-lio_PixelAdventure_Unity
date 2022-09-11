using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer rend;
    public float speed, jumpForce = 0f;
    private bool isJumping, doubleJump;
    private float inputHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isJumping = false;
            anim.SetBool("isJumping", false);
            anim.SetBool("isDoubleJump", false);
            anim.SetBool("isFall", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isJumping = true;
            anim.SetBool("isJumping", true);
        }
    }

    private void Inputs()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (inputHorizontal != 0)
        {
            anim.SetBool("isRun", true);
            if (Input.GetKeyDown(KeyCode.Space)) {
                anim.SetBool("isJumping", true);
            }
            if (inputHorizontal > 0)
            {
                rend.flipX = false;
            }

            else
            {
                rend.flipX = true;
            }
        }
        else { anim.SetBool("isRun", false); }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
            }
            else
            {
                if (doubleJump)
                {
                    anim.SetBool("isDoubleJump", true);
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);;
                    doubleJump = false;
                }
                else
                {
                    anim.SetBool("isFall", true);
                }
            }
        }

    }
}

