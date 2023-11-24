using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SoundButtonPlay : MonoBehaviour
{
    public AudioSource soundPlayer;
    



    public void playThisSoundEffect()
    {
        soundPlayer.Play();
    }

}
