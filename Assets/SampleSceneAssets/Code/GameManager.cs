using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public MusicData musicSelect;
    private AudioSource source;

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

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    public void SetMusicToPlay(MusicData musicSelect)
    {
        this.musicSelect = musicSelect;
    }

    public void StartGame()
    {
        source.clip = musicSelect.music;
        source.Play();
    }
}
