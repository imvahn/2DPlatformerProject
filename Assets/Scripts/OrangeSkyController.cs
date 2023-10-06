using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSkyController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))//orange scene
        {
            spriteRenderer.sortingOrder = 1;
        }
        else if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.R))
        {
            spriteRenderer.sortingOrder = -1;
        }
    }
}
