using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerMovement : MonoBehaviour
{
    public Animator startAnimation;
    public S_PlayerSpeed playerSpeed;
    public float jumpStrength;

    private S_PlayerGravity gravity;

    private bool player1DoubleJump;
    private bool player2DoubleJump;
    private float jumpDelay;

    private Rigidbody2D rb;

    public Transform checkGround;
    private float groundRadius = 0.2f;
    public LayerMask ground;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = gravity.value;
    }

    private void Update()
    {
        if (startAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7)
        {
            transform.position += Vector3.right * playerSpeed.value * Time.deltaTime;
        }

        if (IsGrounded() && Player1And2IsJumping())
        {
            DoubleJump();
        }
        else if (IsGrounded() && Player1IsJumping() && !Player2IsJumping())
        {
            player2DoubleJump = true;
            Jump();
        }
        else if (IsGrounded() && Player2IsJumping() && !Player1IsJumping())
        {
            player1DoubleJump = true;
            Jump();
        }
        else if (!IsGrounded())
        {
            if (player1DoubleJump && Player1IsJumping() && !Player2IsJumping() && Time.time < jumpDelay)
            {
                player1DoubleJump = false;
                DoubleJump();
            }
            if (player2DoubleJump && Player2IsJumping() && !Player1IsJumping() && Time.time < jumpDelay)
            {
                player2DoubleJump = false;
                DoubleJump();
            }
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
        jumpDelay = Time.time + 0.3f;
    }

    public void DoubleJump()
    {
        if (rb.velocity.y < 0 && !IsGrounded())
        {
            rb.velocity = Vector2.zero;
            rb.velocity += new Vector2(rb.velocity.x, jumpStrength / 3f);
        }
        else if (rb.velocity.y >= 0 && !IsGrounded())
        {
            rb.velocity += new Vector2(rb.velocity.x, jumpStrength / 3f);
        }
        else
        {
            Jump();
        }
    }

    public bool Player1IsJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        return false;
    }
    public bool Player2IsJumping()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return true;
        }
        return false;
    }

    public bool Player1And2IsJumping()
    {
        if ((Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKey(KeyCode.Space)))
        {
            return true;
        }
        return false;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(checkGround.position, groundRadius, ground);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            print("Music");
        }
    }
}