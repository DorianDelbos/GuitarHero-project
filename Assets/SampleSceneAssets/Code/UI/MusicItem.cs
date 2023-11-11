using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicItem : MonoBehaviour
{
    [SerializeField] private RawImage firstImage;
    [SerializeField] private TextMeshProUGUI titleMesh;
    [SerializeField] private TextMeshProUGUI authorMesh;
    [SerializeField] private GameObject difficultyGameObject;
    [SerializeField] private Texture starFullTexture;

    public EventInstance previewSong { get; private set; }

    public void OnClick()
    {
        RuntimeManager.PlayOneShot("event:/UI/Click");
        SelectionMusic.instance.StopAllMusics();
        previewSong.start();
    }

    public void SetFirstImage(Texture image)
    {
        firstImage.texture = image;
    }

    public void SetTitle(string title)
    {
        titleMesh.text = title;
    }

    public void SetAuthor(string author)
    {
        authorMesh.text = author;
    }

    public void SetDifficulty(int difficulty)
    {
        difficulty = Mathf.Clamp(difficulty, 1, 8);

        for (int i = 0; i < difficulty; i++)
        {
            difficultyGameObject.transform.GetChild(i).GetComponent<RawImage>().texture = starFullTexture;
        }
    }

    public void SetPreviewSong(EventReference previewSong)
    {
        this.previewSong = RuntimeManager.CreateInstance(previewSong);
    }
}
