using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RhythmZone : MonoBehaviour
{
    [SerializeField] private InputActionReference input;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private GameObject visuelPressButton;
    [SerializeField] private Color colorPressButton;
    private GameObject objectInTrigger;
    private Coroutine coroutine;

    private void Start()
    {
        objectInTrigger = null;
    }

    private void Update()
    {
        if (input.action.WasPerformedThisFrame())
        {
            visuelPressButton.GetComponent<MeshRenderer>().material.color = colorPressButton;

            if (coroutine == null)
            {
                coroutine = StartCoroutine(ResetButton());
            }

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
        GameManager.instance.AddScore(10);
    }

    private void Failed()
    {
        CameraShake.instance.ShakeCamera(5f, 0.25f);
        GameManager.instance.AddScore(-1);
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

    private IEnumerator ResetButton()
    {
        yield return new WaitForSeconds(0.1f);

        visuelPressButton.GetComponent<MeshRenderer>().material.color = Color.white;
        coroutine = null;
    }
}
