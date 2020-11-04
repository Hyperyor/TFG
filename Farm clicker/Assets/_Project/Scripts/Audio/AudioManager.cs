using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [Header("Audio")]
    public AudioSource Sound;
    public AudioMixer audioMixer;

    [Header("Audio Effects")]
    public AudioClip Coin;
    public AudioClip cash;

    
    public AudioData serializedData;

    public void Start()
    {
        serializedData = new AudioData();
        LoadVolumeData();
    }


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
    
    public void SaveVolumeData()
    {
        float volume;

        //we take the actual volume value (for each variable on the mixer) on "volume" 
        //float to save it on our serializable class so we can save it later on our json

        audioMixer.GetFloat("MasterVolume", out volume);
        serializedData.masterVolume = volume;

        audioMixer.GetFloat("MusicVolume", out volume);
        serializedData.musicVolume = volume;

        audioMixer.GetFloat("EffectsVolume", out volume);
        serializedData.effectsVolume = volume;

        JsonSaver.SaveObject(serializedData);
    }

    public void LoadVolumeData()
    {
        serializedData = JsonSaver.GetFile<AudioData>();

        audioMixer.SetFloat("MasterVolume", serializedData.masterVolume);
        audioMixer.SetFloat("MusicVolume", serializedData.musicVolume);
        audioMixer.SetFloat("EffectsVolume", serializedData.effectsVolume);
        
    }
}
