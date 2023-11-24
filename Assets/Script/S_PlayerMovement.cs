using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerMovement : MonoBehaviour
{
    public S_PlayerSpeed playerSpeed;

    public float jumpPower;
    public float gravity;

    private bool player1Jump = false;
    private bool player2Jump = false;

    public float jumpTiming;

    private Transform groundCheck;
    private Rigidbody2D rb;
    private float groundCheckRadius = 0.2f;

    public LayerMask ground;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
        groundCheck = transform.Find("GroundCheck");
    }

    private void Update()
    {
        transform.position += Vector3.right * playerSpeed.value * Time.deltaTime;

        if ((Isgrounded() || player2Jump) && Input.GetKeyDown(KeyCode.Space))
        {
            //print("Space Pressed");
            player1Jump = true;
            player2Jump = false;
            Jump();
        }
        if ((Isgrounded() || player1Jump) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            //print("UpArrow Pressed");
            player2Jump = true;
            player1Jump = false;
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    IEnumerator DoubleJump()
    {
        yield return new WaitForSeconds(jumpTiming);
        player1Jump = false;
        player2Jump = false;
    }

    private bool Isgrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //print("Collision enter");
        player1Jump = false;
        player2Jump = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(DoubleJump());
    }
}
