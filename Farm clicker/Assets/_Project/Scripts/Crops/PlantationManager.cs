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

        public Plantation plantation;

        private void Awake()
        {
            //load saves from file
            LoadData();
        }

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
            SavePlantationData();
        }

        public void PlantSeed(int id)
        {
            Crop crop = Managers.Instance.cropsMan.GetCropAt(id);

            Managers.Instance.gameManager.Buy(crop.GetPrice());

            selectedCropSpace.SetCropImage(crop);
            selectedCropSpace.cropSpaceData.crop = id;
            cropsMenu.gameObject.SetActive(false);

            SavePlantationData();
        }

        public void LoadData()
        {
            plantation.LoadPlantationData();
        }

        public void SavePlantationData()
        {
            DataManager.plantationData.harvestLineList.Clear();

            plantation.SavePlantationData();

            DataManager.SaveData();
        }
    }
}
