using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolutions;

    public Dropdown resolutionDropdown, qualityDropdown;

    bool isFull;

    public Toggle windowToggle;

    int quality;

    public AudioSource audio;

    public Slider volume;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        isFull = Screen.fullScreen;
        windowToggle.isOn = isFull;

        quality = QualitySettings.GetQualityLevel();
        qualityDropdown.value = quality;

        volume.value = audio.volume;


    }

    public void SetResolution(int resolutionIndex) {

        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        Debug.Log(resolution.width + "+" + resolution.height);
    }
    public void SetVolume(float volume)
    {
        audio.volume = volume;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
