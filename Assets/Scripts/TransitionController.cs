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
        if (PlayerInstrument.pickingUp[1] == true)  //guitar (green)
        {
            animator.SetInteger("Transition", 1);
        }

        if (PlayerInstrument.pickingUp[3] == true) //drums (orange)
        {
            animator.SetInteger("Transition", 2);
        }

        if (PlayerInstrument.pickingUp[2] == true) //flute (purple)
        {
            animator.SetInteger("Transition", 3);
        }

        if (PlayerInstrument.pickingUp[0] == true) //piano (light green)
        {
            animator.SetInteger("Transition", 4);
        }
    }
}
