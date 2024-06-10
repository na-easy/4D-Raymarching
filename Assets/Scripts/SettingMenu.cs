using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class SettingMenu : MonoBehaviour
{
    private static readonly string QualitySettingPreference = "QualitySettingPreference";
    private static readonly string ResolutionPreference = "ResolutionPreference";
    private static readonly string FullscreenPreference = "FullscreenPreference";

    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Toggle fullscreenToggle;

    Resolution[] resolutions;

    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings();
    }

    public void SetFullscreen()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void SetResolution()
    {
        Resolution resolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(qualityDropdown.value);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt(QualitySettingPreference, qualityDropdown.value);
        PlayerPrefs.SetInt(ResolutionPreference, resolutionDropdown.value);
        PlayerPrefs.SetInt(FullscreenPreference, System.Convert.ToInt32(fullscreenToggle.isOn));
    }

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey(QualitySettingPreference))
            qualityDropdown.value = PlayerPrefs.GetInt(QualitySettingPreference);
        else
            qualityDropdown.value = qualityDropdown.value;
        if (PlayerPrefs.HasKey(ResolutionPreference))
            resolutionDropdown.value = PlayerPrefs.GetInt(ResolutionPreference);
        else
            resolutionDropdown.value = resolutionDropdown.value;
        if (PlayerPrefs.HasKey(FullscreenPreference))
            fullscreenToggle.isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt(FullscreenPreference));
        else
            fullscreenToggle.isOn = false;
    }
}
