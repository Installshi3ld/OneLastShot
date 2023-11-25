using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SoundButtonSettings : MonoBehaviour
{
    public AudioSource soundPlayer;



    public void playThisSoundEffect()
    {
        soundPlayer.Play();
    }
}
