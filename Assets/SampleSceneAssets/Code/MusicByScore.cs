using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicByScore : MonoBehaviour
{
    public static MusicByScore instance;

    public float currentTime { get; private set; }

    private EventInstance[] songToPlay = new EventInstance[4];
    private EventInstance leadSong;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentTime = 0f;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    public void SetMusic(MusicData data)
    {
        for (int i = 0; i < songToPlay.Length; i++)
        {
            songToPlay[i] = RuntimeManager.CreateInstance(data.songByKey[i]);
        }
        leadSong = RuntimeManager.CreateInstance(data.leadSong);
    }

    public void SetParameter(int valToChange, int score, int averageScore)
    {
        songToPlay[valToChange].setParameterByName("Score", score);
        leadSong.setParameterByName("Score", averageScore);
    }

    public void StartGame()
    {
        GameManager.instance.ResetScore();

        for (int i = 0; i < songToPlay.Length; i++)
        {
            songToPlay[i].start();
        }
        leadSong.start();
    }

    public void StopGame()
    {
        Time.timeScale = 1f;

        for (int i = 0; i < songToPlay.Length; i++)
        {
            songToPlay[i].stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        leadSong.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    public void PauseGame()
    {
        for (int i = 0; i < songToPlay.Length; i++)
        {
            songToPlay[i].setPaused(true);
        }
        leadSong.setPaused(true);
    }

    public void UnPauseGame()
    {
        for (int i = 0; i < songToPlay.Length; i++)
        {
            songToPlay[i].setPaused(false);
        }
        leadSong.setPaused(false);
    }
}
