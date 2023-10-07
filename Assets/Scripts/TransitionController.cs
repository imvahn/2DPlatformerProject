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
        if (PlayerInstrument.currentInstrument == Instrument.Guitar) //guitar (green)
        {
            animator.SetInteger("Transition", 1);
        }

        if (PlayerInstrument.currentInstrument == Instrument.Drums)//drums (orange)
        {
            animator.SetInteger("Transition", 2);
        }

        if (PlayerInstrument.currentInstrument == Instrument.Flute)//flute (purple)
        {
            animator.SetInteger("Transition", 3);
        }

        if (PlayerInstrument.currentInstrument == Instrument.Piano) //piano (light green)
        {
            animator.SetInteger("Transition", 4);
        }
    }
}
