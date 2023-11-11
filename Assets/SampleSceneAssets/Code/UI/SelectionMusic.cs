using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionMusic : MonoBehaviour
{
    public static SelectionMusic instance;

    [SerializeField] private GameObject musicItemPrefab;
    [SerializeField] private Transform musicItemListTransform;

    [SerializeField] private TextMeshProUGUI titleMesh;
    [SerializeField] private TextMeshProUGUI authorMesh;
    [SerializeField] private RawImage firstImage;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetMusicData(GameAssets.instance.musicDatas[0]);

        foreach (MusicData data in GameAssets.instance.musicDatas)
        {
            GameObject musicItem = Instantiate(musicItemPrefab, musicItemListTransform);

            Button musicItemButton = musicItem.GetComponent<Button>();
            musicItemButton.onClick.AddListener(() => SetMusicData(data));

            MusicItem musicItemScript = musicItem.GetComponent<MusicItem>();
            musicItemScript.SetTitle(data.title);
            musicItemScript.SetAuthor(data.author);
            musicItemScript.SetDifficulty(data.difficulty);
            musicItemScript.SetFirstImage(data.firstImage);
            musicItemScript.SetPreviewSong(data.previewSong);
        }

        musicItemListTransform.GetComponent<VerticalLayoutGroup>().CalculateLayoutInputVertical();
    }

    public void SetMusicData(MusicData data)
    {
        GameManager.instance.SetMusicToPlay(data);
        titleMesh.text = data.title;
        authorMesh.text = data.author;
        firstImage.texture = data.firstImage;
    }

    public void StopAllMusics()
    {
        foreach (Transform child in musicItemListTransform)
        {
            if (child.TryGetComponent<MusicItem>(out MusicItem comp))
            {
                comp.previewSong.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            }
        }
    }
}
