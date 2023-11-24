using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GameManager : MonoBehaviour
{
    private float masterVolume;
    private bool isfullScreen;

    public void SetMasterVolume(float volume)
    {
        masterVolume = Mathf.Clamp01(volume);
    }

    public void ToggleFullScreen()
    {
        isfullScreen = !isfullScreen;
        Screen.fullScreen = isfullScreen;
    }

    public float GetMasterVolume() { return masterVolume; }
    public bool IsFullScreen() { return isfullScreen; }
}
