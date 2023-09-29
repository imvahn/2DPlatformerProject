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
     
    }

    public Instrument GetInstrument()
    {
        return currentInstrument;
    }

}
