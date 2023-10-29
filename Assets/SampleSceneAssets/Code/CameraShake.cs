using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance { get; private set; }

    private CinemachineVirtualCamera vc;
    private float shakeTimer;

    private void Awake()
    {
        instance = this;

        vc = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin perlin = vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0)
            {
                // Timer over !
                CinemachineBasicMultiChannelPerlin perlin = vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                perlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
