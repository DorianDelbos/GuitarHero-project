using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private Transform noteTransform;

    public int[][] map;

    private void Start()
    {
        TextAsset mapFile = GameManager.instance.musicSelect.map;
        map = MapFileParser.Parse(mapFile);

        GenerateMap();
    }

    private void GenerateMap()
    {
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < spawners.Length; j++)
            {
                if (map[i][j] != 0)
                {
                    Vector3 position = spawners[j].transform.position;
                    position.z += 10 * i;

                    Instantiate(notePrefab, position, Quaternion.identity, noteTransform);
                }
            }
        }
    }
}
