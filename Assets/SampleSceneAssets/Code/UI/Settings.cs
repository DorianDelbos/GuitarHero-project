using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private List<Resolution> resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions.ToList();
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int curResolutionIndex = 0;
        for (int i = resolutions.Count - 1; i >= 0; i--)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            if (options.Contains(option))
            {
                resolutions.RemoveAt(i);
                continue;
            }

            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                curResolutionIndex = i;
            }
        }

        options.Reverse();
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = curResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
