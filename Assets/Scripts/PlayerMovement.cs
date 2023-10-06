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
    public GameObject pauseMenu;

    public LayerMask platformLayerMask;

    public bool isGrounded;
    public bool isRunning;
    public bool isPaused;

    private float lastJumpTime;
    public float bounceWindow = 2f;

    public static bool swapped = false;

    private int jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isPaused = false;
        pauseMenu.SetActive(false);
}

    // Update is called once per frame
    void Update()
    {
        /*
        if player swaps instrument, change currentInstrument

        inventory[0] is piano     (1)
        inventory[1] is guitar    (2)
        inventory[2] is flute     (3)
        inventory[3] is drums     (4)
         */ 
        if (Input.GetKeyDown(KeyCode.Alpha1) && PlayerInstrument.inventory[0] == true && swapped == false && PlayerInstrument.currentInstrument != Instrument.Piano)
        {
            swapped = true;
            PlayerInstrument.currentInstrument = Instrument.Piano;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && PlayerInstrument.inventory[1] == true && swapped == false && PlayerInstrument.currentInstrument != Instrument.Guitar)
        {
            swapped = true;
            PlayerInstrument.currentInstrument = Instrument.Guitar;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && PlayerInstrument.inventory[2] == true && swapped == false && PlayerInstrument.currentInstrument != Instrument.Flute)
        {
            swapped = true;
            PlayerInstrument.currentInstrument = Instrument.Flute;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && PlayerInstrument.inventory[3] == true && swapped == false && PlayerInstrument.currentInstrument != Instrument.Drums)
        {
            swapped = true;
            PlayerInstrument.currentInstrument = Instrument.Drums;
        }

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
                    if (PlayerInstrument.currentInstrument == Instrument.Drums)
                    {
                        // Check if within the bounce window
                        if (jumpCount >= 1) // DONE need to make this work
                        {
                            vel.y = 2f * jumpForce;  // Bounce effect
                            jumpCount = 0;
                        }
                        else
                        {
                            vel.y = jumpForce;  // Normal jump
                            jumpCount++;
                    
                        }
                    }
                    else
                    {
                        // For instruments other than drums, always do a normal jump
                        vel.y = jumpForce;
                    }
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

        //if (transform.position.y < -6)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
    }
}