using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [Header("Audio")]
    public AudioSource Sound;

    [Header("Audio Effects")]
    public AudioClip Coin;
    public AudioClip cash;

    // Method of playing effect, accepts any effect from cached
    public void PlaySound(AudioClip sound)
    {
        Sound.clip = sound;
        Sound.Play();
    }

    public void ChangeVolume(AudioMixer audioMix, float sliderValue, string volumeValue)
    {
        //inicial = 0
        //final = -40
        //final - inicial - final * valor + final
        float finalVolumeValue = 0 - (-40) * sliderValue + -40;

        if (finalVolumeValue == -40)
        {
            finalVolumeValue = -80;
        }

        audioMix.SetFloat(volumeValue, finalVolumeValue);
    }
}
