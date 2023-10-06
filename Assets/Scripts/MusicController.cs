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
        if (PlayerInstrument.GetInstrument() != Instrument.Piano)
        {
            if (PlayerInstrument.GetInstrument() == Instrument.Flute) { current = fluteMusic; }
            if (PlayerInstrument.GetInstrument() == Instrument.Drums) { current = drumMusic; }
            if (PlayerInstrument.GetInstrument() == Instrument.Guitar) { current = guitarMusic; }
        }
    }
}
