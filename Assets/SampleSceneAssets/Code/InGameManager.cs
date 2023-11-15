using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreMesh;
    [SerializeField] private TextMeshProUGUI timeTextMesh;
    [SerializeField] private Slider musicLength;

    void Start()
    {
        GameManager.instance.onScoreChanged += UpdateScoreText;

        MusicByScore.instance.SetMusic(GameManager.instance.musicSelect);
        MusicByScore.instance.StartGame();

        musicLength.maxValue = (int)GameManager.instance.musicSelect.timeInSeconds;
    }

    private void Update()
    {
        timeTextMesh.text = FormatTime((int)musicLength.value) + " / " + FormatTime((int)musicLength.maxValue);
        musicLength.value = MusicByScore.instance.currentTime;

        if (musicLength.value >= musicLength.maxValue)
        {
            MusicByScore.instance.StopGame();
            SceneManager.LoadScene("EndMenu");
        }
    }

    private void UpdateScoreText()
    {
        currentScoreMesh.text = "CURRENT SCORE   " + GameManager.instance.averageScore.ToString("D3");
    }

    private string FormatTime(int seconds)
    {
        int minutes = seconds / 60;
        int remainingSeconds = seconds % 60;

        string formattedTime = string.Format("{0:D2}:{1:D2}", minutes, remainingSeconds);

        return formattedTime;
    }
}
