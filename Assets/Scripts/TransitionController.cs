using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetInteger("Transition", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))//green scene
        {
            animator.SetInteger("Transition", 1);
        }

        if (Input.GetKey(KeyCode.W))//orange scene
        {
            animator.SetInteger("Transition", 2);
        }

        if (Input.GetKey(KeyCode.E))//purple scene
        {
            animator.SetInteger("Transition", 3);
        }

        if (Input.GetKey(KeyCode.R))//light green scene
        {
            animator.SetInteger("Transition", 4);
        }
    }
}
