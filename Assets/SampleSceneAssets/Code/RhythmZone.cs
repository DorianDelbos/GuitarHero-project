using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;
using FMOD.Studio;
using System.Diagnostics.Tracing;

public class RhythmZone : MonoBehaviour
{
    [SerializeField] private InputActionReference input;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private GameObject visuelPressButton;
    [SerializeField] private Color colorPressButton;
    [SerializeField] private int toScored;
    private GameObject objectInTrigger;

    [SerializeField] private EventInstance songToPlay;

    private void Start()
    {
        objectInTrigger = null;
    }

    private void Update()
    {
        if (input.action.IsPressed())
        {
            visuelPressButton.GetComponent<MeshRenderer>().material.color = colorPressButton;
        }
        else
        {
            visuelPressButton.GetComponent<MeshRenderer>().material.color = Color.white;
        }

        if (input.action.WasPerformedThisFrame())
        {
            RuntimeManager.PlayOneShot("event:/UI/Click");

            if (objectInTrigger)
            {
                Success();
            }
            else
            {
                Failed();
            }

            if (songToPlay.isValid())
                songToPlay.setParameterByName("Score", GameManager.instance.scoreToAverage[toScored]);
        }
    }

    private void Success()
    {
        particles.Play();
        Destroy(objectInTrigger);
        objectInTrigger = null;
        GameManager.instance.AddScore(toScored, 10);
    }

    private void Failed()
    {
        CameraShake.instance.ShakeCamera(5f, 0.25f);
        GameManager.instance.AddScore(toScored, -10);
    }

    private void OnTriggerEnter(Collider other)
    {
        objectInTrigger = other.gameObject;
        other.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectInTrigger)
        {
            Failed();
            objectInTrigger = null;
            other.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
