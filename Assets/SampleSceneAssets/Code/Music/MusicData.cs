using UnityEngine;

[CreateAssetMenu(fileName = "New music data", menuName = "Music Data")]
public class MusicData : ScriptableObject
{
    public string title = "NONE";
    public string author = "NONE";
    public Texture firstImage;
    [TextArea(5, 10)] public string description = "";
    [Range(30, 300)] public int beatPerMinutes = 100;
    [Range(1, 8)] public short difficulty = 1;
    public AudioClip music;
    public bool randomMap;
    public int mapLength;
    public TextAsset map;
}
