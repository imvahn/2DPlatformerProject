using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstrument : MonoBehaviour
{
    // Start is called before the first frame update

    Instrument currentInstrument;
    public Instrument instrument;
    
    void Start()
    {
        currentInstrument = instrument.piano;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    Instrument GetInsrument()
    {
        return currentInstrument;
    }

}
