using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float bendTime;
    public float jumpTime;
    public float raycastLength = 0.84f;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    public Animator animator;
    public Sprite pinkGuy;

    public LayerMask platformLayerMask;

    public bool isGrounded;
    public bool isRunning;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        bendTime = 0.333f;
        jumpTime = 0.1f;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {

        // Check if the game is paused (player pressed escape)
        if (Input.GetKey(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

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

        //Check if game is paused
        if (isPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isGrounded)
                {
                    StartCoroutine(Jumping());
                }
            }
            vel.x = Input.GetAxis("Horizontal") * speed;
            rb2d.velocity = vel;
        }

        // Animator logic

        if (Mathf.Abs(vel.x) > 0.01 && isGrounded)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if (isRunning && isGrounded)
        {
            animator.SetBool("isWalking", true);
        }
        else if (isRunning && !isGrounded)
        {
            animator.SetBool("isWalking", false);
        }
        else if (!isRunning && isGrounded)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        
        // Flip X depending on which direction the player is moving

        if (vel.x > 0.01)
        {
            spriteRenderer.flipX = false;
        }
        else if (vel.x < -0.01)
        {
            spriteRenderer.flipX = true;
        }

        // Restart the scene if the player falls out of bounds

        if (transform.position.y < -6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator Jumping()
    {
        animator.SetBool("isW", true);
        yield return new WaitForSeconds(bendTime);
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        yield return new WaitUntil(() => rb2d.velocity.y < -0.01f);
        animator.SetBool("isW", false);
        animator.SetBool("isFalling", true);
        yield return new WaitUntil(() => rb2d.velocity.y > -0.01f);
        animator.SetBool("isFalling", false);
        yield break;
    }
}