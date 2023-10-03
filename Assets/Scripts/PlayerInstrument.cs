using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstrument : MonoBehaviour
{
    // Start is called before the first frame update

    Instrument currentInstrument;
    List<Instrument> inventory = new List<Instrument>(new Instrument[4]);


    void Start()
    {
        // starting instrument is currently piano
        currentInstrument = Instrument.piano;
        inventory[0] = Instrument.piano;
    }

    // Update is called once per frame
    void Update()
    {
       // if player picks up new isntrument: add to list,
       // if player swaps instrument, change currentInstrument

        //inventory[0] is piano     (1)
        //inventory[1] is guitar    (2)
        //inventory[2] is flute     (3)
        //inventory[3] is drums     (4)
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

    public List<Instrument> GetInventory()
    {
        return inventory;
    }
    public Instrument GetInstrument()
    {
        return currentInstrument;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "instrument") //this can be changed later since comparing with tags is terrible
        {
            if (collision.name == "piano")
            {
                inventory[0] = Instrument.piano;
            }
            if (collision.name == "guitar")
            {
                inventory[1] = Instrument.guitar;
            }
            if (collision.name == "flute")
            {
                inventory[2] = Instrument.flute;
            }
            if (collision.name == "drums")
            {
                inventory[3] = Instrument.drums;
            }
            Destroy(collision.gameObject);
        }
    }

}
