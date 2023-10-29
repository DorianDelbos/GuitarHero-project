using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicItem : MonoBehaviour
{
    [SerializeField] private Image firstImage;
    [SerializeField] private TextMeshProUGUI titleMesh;
    [SerializeField] private TextMeshProUGUI authorMesh;

    public void SetFirstImage(Image image)
    {
        firstImage = image;
    }

    public void SetTitle(string title)
    {
        titleMesh.text = title;
    }

    public void SetAuthor(string author)
    {
        authorMesh.text = author;
    }
}
