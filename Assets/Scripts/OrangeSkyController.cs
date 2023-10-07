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
        if (PlayerInstrument.currentInstrument == Instrument.Drums)//orange scene (drums)
        {
            spriteRenderer.sortingOrder = 1;
        }
        else if (PlayerInstrument.currentInstrument == Instrument.Guitar || PlayerInstrument.currentInstrument == Instrument.Piano || PlayerInstrument.currentInstrument == Instrument.Flute)
        { 
            spriteRenderer.sortingOrder = -1;
        }
    }
}
