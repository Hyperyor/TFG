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

    //properties doesn't work so well with serialization it seems, should look it out later

    //public float Master   // property
    //{
    //    get { return masterVolume; }
    //    set { masterVolume = value; }
    //}
    
    //public float Music   // property
    //{
    //    get { return musicVolume; }
    //    set { musicVolume = value; }
    //}
    
    //public float Effects   // property
    //{
    //    get { return effectsVolume; }
    //    set { effectsVolume = value; }
    //}
}
