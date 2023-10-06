using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform currentCheckpoint; // Store the current checkpoint

    // Detect when the player falls
    void Update()
    {
        if (transform.position.y < -10f)
        { 
            Respawn(); // Call the respawn function
        }
    }

    // Function to respawn the player at the current checkpoint
    public void Respawn()
    {
        if (currentCheckpoint != null)
        {
            // Teleport the player to the checkpoint's position
            transform.position = currentCheckpoint.position;
        }
    }

    // Function to detect if the player has passed the checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;
        }
    }
}
