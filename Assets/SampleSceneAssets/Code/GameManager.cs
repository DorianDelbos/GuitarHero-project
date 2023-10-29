using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Action onScoreChanged;

    public MusicData musicSelect;
    public AudioSource source;

    public int currentScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameObject.transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore = Mathf.Clamp(currentScore + scoreToAdd, 0, int.MaxValue);
        onScoreChanged?.Invoke();
    }

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    public void SetMusicToPlay(MusicData musicSelect)
    {
        this.musicSelect = musicSelect;
    }
}
