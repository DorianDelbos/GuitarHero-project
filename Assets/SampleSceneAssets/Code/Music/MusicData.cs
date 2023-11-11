using FMOD.Studio;
using FMODUnity;
using UnityEngine;

[CreateAssetMenu(fileName = "New music data", menuName = "Music Data")]
public class MusicData : ScriptableObject
{
    public enum Difficulty
    {
        Hard,
        Medium,
        Easy
    }

    [Header("Generals data")]
    public string title = "NONE";
    public string author = "NONE";
    public Texture firstImage;
    [TextArea(5, 10)] public string description = "";

    [Space, Header("Sounds data")]
    [Range(30, 300)] public int beatPerMinutes = 100;
    [Range(1, 8)] public short difficulty = 1;
    public Difficulty difficultyLvl = Difficulty.Easy;

    public float timeInSeconds;

    [Space, Header("Fmod data")]
    public EventReference[] songByKey = new EventReference[4];
    public EventReference leadSong;
    public EventReference previewSong;
}
