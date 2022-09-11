using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer rend;
    public float speed, jumpForce = 0f;
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
        VerificationAnimator();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
        
    }
    private void Inputs()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (inputHorizontal != 0)
        {
            if (inputHorizontal > 0)
            {
                rend.flipX = false;
            }

            else
            {
                rend.flipX = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

    }

    private void VerificationAnimator()
    {
        if(inputHorizontal != 0)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }
}
