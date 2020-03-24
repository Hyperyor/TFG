using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crops;

namespace Core
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
            cropsMenu.CheckItems();
        }

        public void HideCropsOptions()
        {
            cropsMenu.gameObject.SetActive(false);
        }

        public void PlantSeed(int id)
        {
            Crop crop = Managers.Instance.cropsMan.GetCropAt(id);

            Managers.Instance.gameManager.CropBought(crop.GetPrice());

            selectedCropSpace.SetCropImage(crop);
            cropsMenu.gameObject.SetActive(false);
        }
    }
}
