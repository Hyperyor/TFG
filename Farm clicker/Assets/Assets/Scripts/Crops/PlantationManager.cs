using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crops;

namespace Idle
{
    
    public class PlantationManager : MonoBehaviour
    {
        [SerializeField]
        private CropsMenu cropsMenu;

        private CropSpace selectedCropSpace;

        //Method to show crops options
        public void ShowCropsOptions(CropSpace scs)
        {

            selectedCropSpace = scs;
            cropsMenu.gameObject.SetActive(true);
        }

        public void HideCropsOptions()
        {
            cropsMenu.gameObject.SetActive(false);
        }

        public void PlantSeed(int id)
        {
            Item crop = cropsMenu.GetCropAt(id);

            selectedCropSpace.SetCropImage(crop.crop);
            cropsMenu.gameObject.SetActive(false);
        }
    }
}
