using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderBus : MonoBehaviour
{
    [SerializeField] private string busName;
    [SerializeField] private TMP_Text valueVal;
    private FMOD.Studio.Bus masterBus;
    private Slider slider;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        masterBus = FMODUnity.RuntimeManager.GetBus(busName);
        masterBus.getVolume(out float val);

        ChangeSoundVolume(val);
    }

    public void ChangeSoundVolume(float value)
    {
        masterBus.setVolume(value / slider.maxValue);
        slider.value = value;

        int percent = (int)(value / slider.maxValue * 100);
        valueVal.text = percent + " %";
    }
}
