using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private Transform noteTransform;

    private void Start()
    {
        GenerateRandomMap((int)(GameManager.instance.musicSelect.timeInSeconds / 60f * GameManager.instance.musicSelect.beatPerMinutes));
    }

    private void GenerateRandomMap(int length)
    {
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (Random.Range(0, 4) == 0)
                {
                    Vector3 position = spawners[j].transform.position;
                    position.z += 10 * i;

                    Instantiate(notePrefab, position, Quaternion.identity, noteTransform);
                }
            }
        }
    }
}
