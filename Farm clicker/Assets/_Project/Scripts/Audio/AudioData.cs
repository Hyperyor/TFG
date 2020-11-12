using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioData //cannot be a monobehaviour
{
    [HideInInspector]
    public float masterVolume;
    [HideInInspector]
    public float musicVolume;
    [HideInInspector]
    public float effectsVolume;
    
}
