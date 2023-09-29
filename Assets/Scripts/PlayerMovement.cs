using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb2d;
    public float jumpForce;
    private SpriteRenderer spriteRenderer;
    private float raycastLength = 0.85f;
    public LayerMask platformLayerMask;
    private bool isGrounded;
    public Animator animator;
    private int jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded, update isGrounded

        RaycastHit2D groundCheckHit = Physics2D.Raycast(transform.position, Vector2.down, raycastLength, platformLayerMask);
        if (groundCheckHit.collider != null)
        {
            isGrounded = true;
            
        }
        else
        {
            isGrounded = false;
        }

        // Jumping and horizontal movement

        Vector2 vel = rb2d.velocity;
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                vel.y = jumpForce;

                animator.SetBool("isJumping", true);
                jumpCount++;
            }
        }
        vel.x = Input.GetAxis("Horizontal") * speed;
        rb2d.velocity = vel;

        // Animator logic

        animator.SetFloat("SpeedX", Math.Abs(vel.x));

        // Flip X depending on which direction the player is moving

        if (vel.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (vel.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        // Restart the scene if the player falls out of bounds

        if (transform.position.y < -6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
