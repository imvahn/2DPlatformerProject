using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    AudioSource musicSource;

    public AudioClip drumMusic;
    public AudioClip guitarMusic;
    public AudioClip pianoMusic;
    public AudioClip fluteMusic;

    AudioClip current;

    // Start is called before the first frame update
    void Start()
    {
        current = pianoMusic;
        musicSource = GetComponent<AudioSource>();
        AudioSource.PlayClipAtPoint(current, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInstrument.currentInstrument != Instrument.Piano)
        {
            if (PlayerInstrument.currentInstrument == Instrument.Flute) { current = fluteMusic; }
            if (PlayerInstrument.currentInstrument == Instrument.Drums) { current = drumMusic; }
            if (PlayerInstrument.currentInstrument == Instrument.Guitar) { current = guitarMusic; }
        }
    }
}
