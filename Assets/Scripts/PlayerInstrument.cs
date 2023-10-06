using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerInstrument : MonoBehaviour
{
    static public string currentInstrument;
    public static List<bool> inventory = new List<bool>(new bool[4]) { false, false, false, false };

    // Start is called before the first frame update
    void Start()
    {
        // default starting instrument is currently piano
        currentInstrument = Instrument.Piano;
        inventory[0] = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("instrument"))
        {
            if (other.name == "piano")
                inventory[0] = true;
            else if (other.name == "guitar")
                inventory[1] = true;
            else if (other.name == "flute")
                inventory[2] = true;
            else if (other.name == "drums")
                inventory[3] = true;

            Destroy(other.gameObject);
        }

    }
    public void EmptyInventory()
    {
        inventory = new List<bool>(inventory) { false, false, false, false };
    }

}
