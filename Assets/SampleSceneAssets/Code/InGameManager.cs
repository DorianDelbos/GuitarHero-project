using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class InGameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreMesh;
    [SerializeField] private TextMeshProUGUI timeTextMesh;
    [SerializeField] private Slider musicLength;

    void Start()
    {
        GameManager.instance.onScoreChanged += UpdateScoreText;
        StartGame();

        musicLength.maxValue = (int)GameManager.instance.musicSelect.music.length;
    }

    private void Update()
    {
        timeTextMesh.text = FormatTime((int)musicLength.value) + " / " + FormatTime((int)musicLength.maxValue);
        musicLength.value = GameManager.instance.source.time;
    }

    private void UpdateScoreText()
    {
        currentScoreMesh.text = "CURRENT SCORE   " + GameManager.instance.currentScore.ToString("D5");
    }

    private string FormatTime(int seconds)
    {
        int minutes = seconds / 60;
        int remainingSeconds = seconds % 60;

        string formattedTime = string.Format("{0:D2}:{1:D2}", minutes, remainingSeconds);

        return formattedTime;
    }

    public void StartGame()
    {
        GameManager.instance.source.clip = GameManager.instance.musicSelect.music;
        GameManager.instance.source.Play();
    }

    public void StopGame()
    {
        Time.timeScale = 1f;
        GameManager.instance.source.Stop();
    }
}
