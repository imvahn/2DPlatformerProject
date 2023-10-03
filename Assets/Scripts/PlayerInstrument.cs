using System.Collections.Generic;
using UnityEngine;

public class PlayerInstrument : MonoBehaviour
{
    Instrument currentInstrument;
    public readonly static List<Instrument> inventory = new(new Instrument[4]);
    public static bool pickingUp = false;

    // Start is called before the first frame update
    void Start()
    {
        // default starting instrument is currently piano
        currentInstrument = Instrument.Piano;
        inventory[0] = Instrument.Piano;
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
       if (Input.GetKeyDown(KeyCode.Alpha1) && inventory[0] != null)
       {
            currentInstrument = inventory[0];
       }
       if (Input.GetKeyDown(KeyCode.Alpha2) && inventory[1] != null)
       {
            currentInstrument = inventory[1];
       }
       if (Input.GetKeyDown(KeyCode.Alpha3) && inventory[2] != null)
       {
            currentInstrument = inventory[2];
       }
       if (Input.GetKeyDown(KeyCode.Alpha4) && inventory[3] != null)
       {
            currentInstrument = inventory[3];
       }
    }

    static public List<Instrument> GetInventory()
    {
        return inventory;
    }
    public Instrument GetInstrument()
    {
        return currentInstrument;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("instrument")) //this can be changed later since comparing with tags is terrible
        {
            pickingUp = true; // to be used to freeze playermovement in PlayerMovement
            // including the piano case if we want to change the default instrument
            if (other.name == "piano")
            {
                inventory[0] = Instrument.Piano;
            }
            if (other.name == "guitar")
            {
                inventory[1] = Instrument.Guitar;
            }
            if (other.name == "flute")
            {
                inventory[2] = Instrument.Flute;
            }
            if (other.name == "drums")
            {
                inventory[3] = Instrument.Drums;
            }
            Destroy(other.gameObject); //if we want juice we can make an animation for picking up the 
        }
    }

}
