using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float raycastLength = 0.84f;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    public Animator animator;
    public Sprite pinkGuy;
    public GameObject pauseMenu;

    public LayerMask platformLayerMask;

    public bool isGrounded;
    public bool isRunning;
    public bool isPaused;

    private float lastJumpTime;

    public PlayerInstrument playerInstrument;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isPaused = false;
        pauseMenu.SetActive(false);
        playerInstrument = GetComponent<PlayerInstrument>();
}

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerInstrument.GetInstrument());

        // Check if the game is paused (player pressed escape)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseMenu.SetActive(isPaused);
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
                   // if (playerInstrument.GetInstrument() == Instrument.Drums)
                   // {
                    //    if (Time.time - lastJumpTime <= 1.0)
                   //     {
                      //      vel.y = 2f * jumpForce;
                      //      lastJumpTime = Time.time;
                    //    }
                    //    else
                   //     {
                            vel.y = jumpForce;
                            lastJumpTime = Time.time;
                   //     }
                  //  }
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

        if (vel.y > 0.01)
        {
            animator.SetBool("isW", true);
        }
        else
        {
            animator.SetBool("isW", false);
        }

        if (vel.y < -0.01)
        {
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
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
}