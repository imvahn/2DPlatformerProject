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

    public PlayerInstrument player;
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
        //if player.GetInstrument() != piano { current = player.GetInstrument() } //commented this out because it was preventing me from running anything
    }
}
