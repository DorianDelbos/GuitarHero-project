using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RhythmZone : MonoBehaviour
{
    [SerializeField] private InputActionReference input;
    [SerializeField] private ParticleSystem particles;
    private GameObject objectInTrigger;

    private void Start()
    {
        objectInTrigger = null;
    }

    private void Update()
    {
        if (input.action.WasPerformedThisFrame())
        {
            if (objectInTrigger)
            {
                Success();
            }
            else
            {
                Failed();
            }
        }
    }

    private void Success()
    {
        particles.Play();
        Destroy(objectInTrigger);
        objectInTrigger = null;
        Debug.Log("Success");
    }

    private void Failed()
    {
        CameraShake.instance.ShakeCamera(5f, 0.25f);
        Debug.Log("Failed");
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
