using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInstrument : MonoBehaviour
{
    static public string currentInstrument;
    public static bool[] inventory = new bool[4];
    public static bool pickingUp = false;

    // Start is called before the first frame update
    void Start()
    {
        // default starting instrument is currently piano
        currentInstrument = Instrument.Piano;
        inventory[0] = true;
        inventory[1] = false;
        inventory[2] = false;
        inventory[3] = false;

        //check if inventory full using inventory == [true, true, true, true]
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("instrument"))
        {
            pickingUp = true;

            if (other.name == "piano")
                inventory[0] = true;
            else if (other.name == "guitar")
                inventory[1] = true;
            else if (other.name == "flute")
                inventory[2] = true;
            else if (other.name == "drums")
                inventory[3] = true;

            Destroy(other.gameObject); //TODO instantiate animation if possible
        }

    }

}
