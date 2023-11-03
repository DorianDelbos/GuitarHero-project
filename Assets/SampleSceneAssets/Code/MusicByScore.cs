using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicByScore : MonoBehaviour
{
    public static MusicByScore instance;

    [SerializeField] private EventReference[] songToPlayRef = new EventReference[4];
    [SerializeField] private EventReference leadSongRef;

    private EventInstance[] songToPlay = new EventInstance[4];
    private EventInstance leadSong;

    private void Awake()
    {
        instance = this;

        for (int i = 0; i < songToPlayRef.Length; i++)
        {
            songToPlay[i] = RuntimeManager.CreateInstance(songToPlayRef[i]);
        }
        leadSong = RuntimeManager.CreateInstance(leadSongRef);
    }

    private void Start()
    {
        for (int i = 0; i < songToPlay.Length; i++)
        {
            songToPlay[i].start();
        }
        leadSong.start();
    }

    public void SetParameter(int valToChange, int score, int averageScore)
    {
        songToPlay[valToChange].setParameterByName("Score", score);
        leadSong.setParameterByName("Score", averageScore);
    }
}
