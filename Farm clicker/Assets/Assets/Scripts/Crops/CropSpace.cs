using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Idle;

namespace Crops
{

    public class CropSpace : MonoBehaviour
    {
        [SerializeField]
        private int id;
        public PlantationManager manager;

        public void Click()
        {
            manager.ShowCropsOptions(id);
        }
    }
}
