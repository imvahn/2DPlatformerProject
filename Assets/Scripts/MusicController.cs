using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public AudioClip drumMusic;
    public AudioClip drumTransition;

    public AudioClip guitarMusic;
    public AudioClip guitarTransition;

    public AudioClip pianoMusic;
    public AudioClip pianoTransition;

    public AudioClip fluteMusic;
    public AudioClip fluteTransition;

    AudioClip current;

    // Start is called before the first frame update
    void Start()
    {
        current = pianoMusic;
        AudioSource.PlayClipAtPoint(current, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.swapped == false)
        {
            if (PlayerInstrument.currentInstrument == Instrument.Piano && current != pianoMusic) { StartCoroutine(MusicPlayer(pianoMusic)); }
            else if (PlayerInstrument.currentInstrument == Instrument.Flute && current != fluteMusic) { StartCoroutine(MusicPlayer(fluteMusic)); }
            else if (PlayerInstrument.currentInstrument == Instrument.Drums && current != drumMusic) { StartCoroutine(MusicPlayer(drumMusic)); }
            else if (PlayerInstrument.currentInstrument == Instrument.Guitar && current != guitarMusic) { StartCoroutine(MusicPlayer(guitarMusic)); }
        }
    }

    private IEnumerator MusicPlayer(AudioClip audio)
    {
        if (audio != null)
        {
            if (audio == pianoMusic)
            {
                current = pianoTransition;
            }
            if (audio == fluteMusic)
            {
                current = fluteTransition;
            }
            if (audio == drumMusic)
            {
                current = drumTransition;
            }
            if (audio == guitarMusic)
            {
                current = guitarTransition;
            }
            yield return new WaitForSeconds(9.6f);
            current = audio;
            EndCoroutine(audio);
        }
    }
    void EndCoroutine(AudioClip audio)
    {
        StopCoroutine(MusicPlayer(audio));
    }
}
