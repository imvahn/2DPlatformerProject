using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class InstrumentHolder : MonoBehaviour
{
    SpriteRenderer sr;

    public Sprite flute;
    public Sprite guitar;
    public Sprite piano;
    public Sprite drums;
    Rigidbody2D rb;
    Transform go;  // Changed GameObject to Transform
    bool flash;
    float xPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();

        if (transform.childCount > 0)
        {
            go = transform.GetChild(0);
        }
        if (go != null)
        {
            go.localPosition = new Vector3(0.8f, -0.23f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (go != null)
        {
            // Get the player's y velocity
            float yVelocity = rb.velocity.y;
            float xVelocity = rb.velocity.x;

            // Calculate the y position based on the player's y velocity
            float yPos = -0.23f + Mathf.Max(0, yVelocity * 0.1f);  // Adjust the multiplier as needed
            if (xVelocity > 0)
            {
                xPos = 0.8f + Mathf.Max(0, xVelocity * 0.01f);

            }
            else if (xVelocity < 0)
            {
                xPos = -0.8f + Mathf.Max(0, xVelocity * 0.01f);
            }

            // Set the local position
            go.localPosition = new Vector3(xPos, yPos, 0);
        }

        if (PlayerMovement.swapped == true)
        {
            SwapCooldown();
        }

        if (PlayerInstrument.currentInstrument == Instrument.Piano) { sr.sprite = piano; }
        if (PlayerInstrument.currentInstrument == Instrument.Flute) { sr.sprite = flute;  }
        if (PlayerInstrument.currentInstrument == Instrument.Drums) { sr.sprite = drums;  }
        if (PlayerInstrument.currentInstrument == Instrument.Guitar) { sr.sprite = guitar;  }
    }

    void SwapCooldown()
    {
        flash = true;
        StartCoroutine(CooldownCoroutine());
    }

    void EndCooldown()
    {
        flash = false;
    }
    private IEnumerator CooldownCoroutine()
    {
        float duration = 9.6f;  // Duration in seconds

        float endTime = Time.time + duration;  // Calculate the end time

        while (Time.time < endTime && flash)
        {
            sr.color = Color.black;
            yield return new WaitForSeconds(0.01f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.01f);
        }

        PlayerMovement.swapped = false;
        EndCooldown();
    }

}
