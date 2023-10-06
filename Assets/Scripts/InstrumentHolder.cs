using UnityEngine;

public class InstrumentHolder : MonoBehaviour
{
    SpriteRenderer sr;

    public Sprite flute;
    public Sprite guitar;
    public Sprite piano;
    public Sprite drums;
    Rigidbody2D rb;
    Transform go;  // Changed GameObject to Transform

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();

        if (transform.childCount > 0)
        {
            go = transform.GetChild(0);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (rb.velocity.x > 0.01)
        {
            go.localPosition = new Vector3(0.8f, -0.23f, 0);
        }
        else if (rb.velocity.x < -0.01)  // Change to else if to handle only one condition at a time
        {
            go.localPosition = new Vector3(-0.8f, -0.23f, 0);
        }

        if (PlayerInstrument.currentInstrument == Instrument.Piano) { sr.sprite = piano; }
        if (PlayerInstrument.currentInstrument == Instrument.Flute) { sr.sprite = flute;  }
        if (PlayerInstrument.currentInstrument == Instrument.Drums) { sr.sprite = drums;  }
        if (PlayerInstrument.currentInstrument == Instrument.Guitar) { sr.sprite = guitar;  }
    }
}
