using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private RhythmZone[] rhythmZone;
    [SerializeField] private Transform noteTransform;

    private void Start()
    {
        GenerateRandomMap((int)(GameManager.instance.musicSelect.timeInSeconds / 60f * GameManager.instance.musicSelect.beatPerMinutes));
    }

    private void GenerateRandomMap(int length)
    {
        int valByDif;

        switch (GameManager.instance.musicSelect.difficultyLvl)
        {
            case MusicData.Difficulty.Medium:
                valByDif = 3;
                break;
            case MusicData.Difficulty.Easy:
                valByDif = 2;
                break;
            default:
                valByDif = 4;
                break;
        }


        for (int i = 0; i < length; i++)
        {
            int rdmVal = Random.Range(0, valByDif);
            Vector3 position = spawners[rdmVal].transform.position;
            position.z += 10 * i;

            GameObject note = Instantiate(notePrefab, position, Quaternion.identity, noteTransform);
            note.GetComponent<Renderer>().material.color = rhythmZone[rdmVal].colorPressButton;
        }
    }
}
