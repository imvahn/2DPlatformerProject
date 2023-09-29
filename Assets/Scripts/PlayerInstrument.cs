using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstrument : MonoBehaviour
{
    // Start is called before the first frame update

    Instrument currentInstrument;
    
    void Start()
    {
        currentInstrument = Instrument.piano;
    }

    // Update is called once per frame
    void Update()
    {
       // if player picks up new isntrument: add to list,
       // if player swaps instrument, change currentInstrument
    }

    public Instrument GetInstrument()
    {
        return currentInstrument;
    }

}
