using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Idle;

namespace Crops
{


    public class CropsMenu : MonoBehaviour
    {
        
        [SerializeField]
        public Item[] cropsList = new Item[5];


        public Item GetCropAt(int pos)
        {
            return cropsList[pos];
        }
    }
}
