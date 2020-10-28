using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour {

    [SerializeField]
    private AudioMixer audioMix;
    private float sliderValue;
    private float actualVolume;

    [SerializeField]
    private string volumeVariableName;

    private void Start()
    {
        audioMix.GetFloat(volumeVariableName, out actualVolume);


        GetComponent<Slider>().value = (actualVolume - (-40)) / (0 - (-40));
    }

    public void ChangeVolume()
    {
        sliderValue = GetComponent<Slider>().value;

        Managers.Instance.audioManager.ChangeVolume(audioMix, sliderValue, volumeVariableName);

        ////inicial = 0
        ////final = -40
        ////final - inicial - final * valor + final
        //float finalVolumeValue = 0 - (-40) * sliderValue + -40;

        //if(finalVolumeValue == -40)
        //{
        //    finalVolumeValue = -80;
        //}

        //audioMix.SetFloat(volumeVariableName, finalVolumeValue);
    }
}
