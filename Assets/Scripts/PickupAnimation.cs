using UnityEngine;
using System.Collections;

public class PickupAnimation : MonoBehaviour
{

    SpriteRenderer sr;
    int cfi;
    float frameTimer;
    public float framesPerSecond = 12;
    public Sprite[] sprites;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        frameTimer = (1f / framesPerSecond);
        cfi = 0;
    }

    void Update()
    {
        frameTimer -= Time.deltaTime;

        if (frameTimer <= 0)
        {
            cfi++;
            if (cfi >= sprites.Length)
            {
                Destroy(gameObject);
                return;
            }
            frameTimer = (1f / framesPerSecond);
            sr.sprite = sprites[cfi];
        }
    }
}
