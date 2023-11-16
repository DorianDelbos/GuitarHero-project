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

    private List<MusicItem> musicItems = new List<MusicItem>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
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
            musicItems.Add(musicItemScript);
        }

        SetMusicData(GameAssets.instance.musicDatas[0]);
        musicItems[0].OnClick();

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
            if (child.TryGetComponent(out MusicItem comp))
            {
                comp.emitter.Stop();
            }
        }
    }
}
