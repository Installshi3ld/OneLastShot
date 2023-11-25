using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerMovement : MonoBehaviour
{
    public Animator startAnimation;
    public S_PlayerSpeed playerSpeed;
    public float jumpStrength;

    private S_PlayerGravity gravity;

    private Rigidbody2D rb;

    public Transform checkGround;
    private float groundRadius = 0.2f;
    public LayerMask ground;

    private bool inputJumpPlayer1;
    private bool inputJumpPlayer2;
    private bool canDoubleJump;
    private bool player1Jumped;

    private float jumpTimer;
    public float jumpMaxDelay;

    public AudioSource audioSourceJumping;
    public AudioSource audioSourceLanding;
    public AudioSource audioSourceSliding;
    private bool launched;

    private void Start()
    {
        canDoubleJump = false;
        inputJumpPlayer1 = false;
        inputJumpPlayer2 = false;
        launched = false;

        playerSpeed.value = playerSpeed.defaultValue;

        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = gravity.value;
    }

    private void Update()
    {
        if(canDoubleJump)
        {
            jumpTimer += Time.deltaTime;

            if(jumpTimer >= jumpMaxDelay)
            {
                canDoubleJump = false;
                jumpTimer = 0;
            }
        }

        if (startAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            if (!launched)
            {
                //only once
                audioSourceSliding.loop = true;
                audioSourceSliding.Play();
                launched = true;
            }
            transform.position += Vector3.right * playerSpeed.value * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            inputJumpPlayer1 = true;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            inputJumpPlayer2 = true;
        }
    }

    private void FixedUpdate()
    {
        if(inputJumpPlayer1 && inputJumpPlayer2 && !canDoubleJump) 
        {
            if (IsGrounded())
            {
                DoubleJump();
            }
            inputJumpPlayer1 = false;
            inputJumpPlayer2 = false;
        }

        if ((inputJumpPlayer1 || inputJumpPlayer2) && canDoubleJump )
        {
            if (inputJumpPlayer1 && !player1Jumped)
            {
                TransformJump();
                canDoubleJump = false;
                jumpTimer = 0;
            }
            if (inputJumpPlayer2 && player1Jumped)
            {
                TransformJump();
                canDoubleJump = false;
                jumpTimer = 0;
            }
            
            inputJumpPlayer1 = false;
            inputJumpPlayer2 = false;
        }

        if(inputJumpPlayer1) 
        {
            if (IsGrounded())
            {
                Jump();
                canDoubleJump = true;
                player1Jumped = true;
            }
            inputJumpPlayer1 = false;
        }

        if(inputJumpPlayer2) 
        {
            if (IsGrounded())
            {
                Jump();
                canDoubleJump = true;
                player1Jumped = false;
            }

            inputJumpPlayer2 = false;
        }
    }

    private void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.velocity += new Vector2(rb.velocity.x, jumpStrength);
        audioSourceSliding.Pause();
        audioSourceJumping.Play();
    }

    private void TransformJump()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity = Vector2.zero;
            rb.velocity += new Vector2(rb.velocity.x, jumpStrength / 2f);
        }
        else
        {
            rb.velocity += new Vector2(rb.velocity.x, jumpStrength / 2f);
        }
    }

    private void DoubleJump()
    {
        audioSourceSliding.Pause();
        audioSourceJumping.Play();
        rb.velocity += new Vector2(rb.velocity.x, jumpStrength);
        rb.velocity += new Vector2(rb.velocity.x, jumpStrength / 1.5f);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(checkGround.position, groundRadius, ground);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            canDoubleJump = false;
            audioSourceLanding.Play();
            audioSourceSliding.Play();
        }
    }
}