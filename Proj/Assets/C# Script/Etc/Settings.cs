using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropDown;
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private TMP_Dropdown limitFps;

    private Resolution[] resolutions;

    private void Start()
    {
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    public void SetFullScreen(bool isFollScreen)
    {
        Screen.fullScreen = isFollScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetLimitFps(int limitIndex)
    {
        switch (limitIndex)
        {
            case 0:
                Application.targetFrameRate = 30; 
                break;
            case 1:
                Application.targetFrameRate = 60;
                break;
            case 2:
                Application.targetFrameRate = 90;
                break;
            case 3:
                Application.targetFrameRate = 120;
                break;
        }
    }

    public void ExitAndSaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingsPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropDown.value);
        PlayerPrefs.SetInt("FullScrenPreference", System.Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetInt("LimitFps", Application.targetFrameRate);
        PlayerPrefs.SetInt("limitFpsDropdown", limitFps.value);

        SceneManager.LoadScene("Menu");
    }

    public void LoadSettings(int currentResolutonIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingsPreference"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingsPreference");
        else
            qualityDropdown.value = 1;

        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropDown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            qualityDropdown.value = currentResolutonIndex;

        if (PlayerPrefs.HasKey("FullScrenPreference"))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullScrenPreference"));
        else
            Screen.fullScreen = true;

        if (PlayerPrefs.HasKey("LimitFps"))
        {
            Application.targetFrameRate = PlayerPrefs.GetInt("LimitFps");
            limitFps.value = PlayerPrefs.GetInt("limitFpsDropdown");
        }
        else
        { 
            Application.targetFrameRate = 60;
        }

    }
}
