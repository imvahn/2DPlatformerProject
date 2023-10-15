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
    public float sideLength = 0.2f;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    public Animator animator;
    public GameObject pauseMenu;

    public LayerMask platformLayerMask;

    public bool isGrounded;
    public bool isRunning;
    public bool isPaused;

    public float bounceWindow = 2f;

    public static bool swapped = false;

    private int jumpCount;

    public AudioSource audioSource;
    public AudioClip[] jumpSFX;

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

        // Jumping and horizontal movement

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 vel = rb2d.velocity;
        vel.x = horizontalInput * speed;
        isGrounded = IsGrounded();
        isRunning = Mathf.Abs(horizontalInput) > 0.02;

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
                            audioSource.PlayOneShot(jumpSFX[UnityEngine.Random.Range(0, 2)]);
                            jumpCount = 0;
                        }
                        else
                        {
                            vel.y = jumpForce;  // Normal jump
                            audioSource.PlayOneShot(jumpSFX[UnityEngine.Random.Range(0, 2)]);
                            jumpCount++;

                        }
                    }
                    else
                    {
                        // For instruments other than drums, always do a normal jump
                        vel.y = jumpForce;
                        audioSource.PlayOneShot(jumpSFX[UnityEngine.Random.Range(0, 2)]);
                    }
                }
            }

            vel.x = Input.GetAxis("Horizontal") * speed;
            rb2d.velocity = vel;
        }
        // Animator logic

        if (isRunning && isGrounded)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
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

        // Flip X depending on which direction the player is moving

        if (horizontalInput > 0.01)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput< -0.01)
        {
            spriteRenderer.flipX = true;
        }

        // Restart the scene if the player falls out of bounds

        //if (transform.position.y < -6)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
    }

    // Check if the player is grounded, update isGrounded
    public bool IsGrounded()
    {
        // Calculate the raycast origin at the character's feet
        Vector3 raycastOrigin = transform.position;
        raycastOrigin.y -= raycastLength; // Adjust this value based on your character's size

        Vector3 rayStartLeft = raycastOrigin;
        rayStartLeft.x -= sideLength;
        Vector3 rayStartRight = raycastOrigin;
        rayStartRight.x += sideLength;

        RaycastHit2D hitLeft = Physics2D.Raycast(rayStartLeft, Vector2.down, 0.1f, platformLayerMask);
        RaycastHit2D hitRight = Physics2D.Raycast(rayStartRight, Vector2.down, 0.1f, platformLayerMask);

        if (hitLeft.collider != null || hitRight.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}