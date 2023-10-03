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

    private PlayerInstrument player;
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
        if (player.GetInstrument() != Instrument.piano)
        {
            if (player.GetInstrument() == Instrument.flute) { current = fluteMusic; }
            if (player.GetInstrument() == Instrument.drums) { current = drumMusic; }
            if (player.GetInstrument() == Instrument.guitar) { current = guitarMusic; }
        }
    }
}