using System.Collections;
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

    public AudioSource musicSource;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic(pianoMusic, pianoTransition);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.swapped == true && count == 0)
        {
            if (count == 0)
            {
                StopMusic();
                count = 1;
            }
            // Check if music is currently playing and the instrument has changed
            if (PlayerInstrument.currentInstrument == Instrument.Piano) 
            { 
                PlayMusic(pianoMusic, pianoTransition); 
            }
            else if (PlayerInstrument.currentInstrument == Instrument.Flute) 
            { 
                PlayMusic(fluteMusic, fluteTransition); 
            }
            else if (PlayerInstrument.currentInstrument == Instrument.Drums) 
            { 
                PlayMusic(drumMusic, drumTransition); 
            }
            else if (PlayerInstrument.currentInstrument == Instrument.Guitar) 
            { 
                PlayMusic(guitarMusic, guitarTransition); 
            }
        }
        if (PlayerMovement.swapped == false)
        {
            count = 0;
        }
    }

    private void PlayMusic(AudioClip music, AudioClip transition)
    {
            StartCoroutine(PlayMusicCoroutine(transition, music));
    }

    private IEnumerator PlayMusicCoroutine(AudioClip transition, AudioClip audio)
    {
        musicSource.loop = false;
        musicSource.clip = transition;
        musicSource.Play();
        yield return new WaitForSeconds(9.6f);
        musicSource.clip = audio;
        musicSource.Play();
        musicSource.loop = true;
    }

    private void StopMusic()
    {
        musicSource.Stop();
    }
}
