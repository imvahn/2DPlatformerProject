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
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if player swaps instrument, change currentInstrument

        inventory[0] is piano     (1)
        inventory[1] is guitar    (2)
        inventory[2] is flute     (3)
        inventory[3] is drums     (4)
         */
        if (Input.GetKeyDown(KeyCode.Alpha1) && inventory[0] == true)
        {
            currentInstrument = Instrument.Piano;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && inventory[1] == true)
        {
            currentInstrument = Instrument.Guitar;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && inventory[2] == true)
        {
            currentInstrument = Instrument.Flute;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && inventory[3] == true)
        {
            currentInstrument = Instrument.Drums;
        }
    }

    public static bool[] GetInventory()
    {
        return inventory;
    }
    public static string GetInstrument()
    {
        return currentInstrument;
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
