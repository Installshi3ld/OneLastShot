using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;


public class S_VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] public GameObject panel;

    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private int currentResolutionIndex = 0;

    private bool settingsOpen = false;

    private void Start()
    {
        panel.SetActive(false);

        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resolutionDropdown.ClearOptions();

        for(int i = 0; i < resolutions.Length; i++)
        {
            filteredResolutions.Add(resolutions[i]);
        }
        
        List<string> options = new List<string>();
        
        for(int i = 0; i < filteredResolutions.Count; i++)
        {
            string resolutionsOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height;
            options.Add(resolutionsOption);
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicvolume();
            SetSFXvolume();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OpenSettings();
        }
    }

    public void OpenSettings()
    {
        if (!settingsOpen)
        {
            Time.timeScale = 0;
            settingsOpen = !settingsOpen;
            panel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            settingsOpen = !settingsOpen;
            panel.SetActive(false);
        }
    }

    public void SetMusicvolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music",Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXvolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicvolume();
        SetSFXvolume();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
}
