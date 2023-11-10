using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Action onScoreChanged;

    public MusicData musicSelect;

    public int[] scoreToAverage = new int[4];
    public int averageScore;

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
        for (int i = 0; i < scoreToAverage.Length; i++)
        {
            scoreToAverage[i] = 900;
        }

        AverageCalculate();
        onScoreChanged?.Invoke();
    }

    public void AddScore(int toAverage, int scoreToAdd)
    {
        scoreToAverage[toAverage] = Mathf.Clamp(scoreToAverage[toAverage] + scoreToAdd, 0, 999);
        AverageCalculate();
        MusicByScore.instance.SetParameter(toAverage, scoreToAverage[toAverage], averageScore);
    }

    private void AverageCalculate()
    {
        averageScore = 0;
        for (int i = 0; i < scoreToAverage.Length; i++)
        {
            averageScore += scoreToAverage[i];
        }
        averageScore /= scoreToAverage.Length;

        onScoreChanged?.Invoke();
    }

    public void SetMusicToPlay(MusicData musicSelect)
    {
        this.musicSelect = musicSelect;
    }
}
