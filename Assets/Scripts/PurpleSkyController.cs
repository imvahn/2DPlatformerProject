using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleSkyController : MonoBehaviour
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
        if (PlayerInstrument.currentInstrument == Instrument.Flute)//purple scene (flute)
        {
            spriteRenderer.sortingOrder = 1;
        }
        else if (PlayerInstrument.currentInstrument == Instrument.Guitar || PlayerInstrument.currentInstrument == Instrument.Drums || PlayerInstrument.currentInstrument == Instrument.Piano)
        {
            spriteRenderer.sortingOrder = -1;
        }
    }
}
