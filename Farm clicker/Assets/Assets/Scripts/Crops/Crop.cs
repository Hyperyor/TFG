using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Idle;
using UnityEngine;

namespace Crops
{
    
    public class Crop : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] states;

        public Sprite GetState(int pos)
        {
            return states[pos];
        }

    }
}
