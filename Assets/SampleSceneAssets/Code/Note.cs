using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private float musicLength;
    private float currentTime;
    private Vector3 lastPos;

    private void Start()
    {
        musicLength = GameManager.instance.musicSelect.timeInSeconds * 100;

        lastPos = Vector3.zero;
        lastPos.z = -(musicLength / 60f * GameManager.instance.musicSelect.beatPerMinutes) * 10;
    }

    void Update()
    {
        currentTime = Mathf.Clamp(currentTime + Time.deltaTime, 0f, musicLength);
        transform.position = Vector3.Lerp(Vector3.zero, lastPos, currentTime / musicLength);

        if (currentTime >= musicLength)
        {
            Debug.Log("End");
        }
    }
}
