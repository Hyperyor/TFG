﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Core;

namespace Crops
{

    public class CropSpace : MonoBehaviour
    {
        [SerializeField]
        //private int id;
        public PlantationManager manager;

        [SerializeField]
        private TextMeshProUGUI addText;

        [SerializeField]
        private Image cropImage;

        private Crop plantedCrop;
        
        public CropSpaceData cropSpaceData;

        public void Click()
        {
            manager.ShowCropsOptions(this);
        }

        public void SetCropImage(Crop c)
        {

            plantedCrop = c;

            ChangeCropState(0);

            this.gameObject.GetComponent<Button>().enabled = false;

            cropImage.gameObject.SetActive(true);

            addText.enabled = false;
            
            gameObject.GetComponent<CooldownClicker>().CD = plantedCrop.HaversTime;
            
            gameObject.GetComponent<CooldownClicker>().StartTimer();
        }

        public void ChangeCropState(int state)
        {
            switch(state)
            {
                case 0:
                    cropImage.sprite = plantedCrop.GetComponent<Crop>().GetState(0);
                    break;
                case 1:
                    cropImage.sprite = plantedCrop.GetComponent<Crop>().GetState(1);
                    break;
                case 2:
                    cropImage.sprite = plantedCrop.GetComponent<Crop>().GetState(2);
                    break;
                case 3:
                    cropImage.sprite = plantedCrop.GetComponent<Crop>().GetState(3);
                    break;
            }
        }

        public Crop GetPlantedCrop()
        {

            return plantedCrop;
        }

        public void DeleteCrop()
        {
            this.gameObject.GetComponent<Button>().enabled = true;

            cropImage.gameObject.SetActive(false);

            addText.enabled = true;

            cropSpaceData.crop = -1;

            gameObject.GetComponent<CooldownClicker>().ShutDown();

            manager.SavePlantationData();
        }

        public void LoadCropSpaceData()
        {
            //re-plant the crop
            SetCropImage(Managers.Instance.cropsMan.GetCropAt(cropSpaceData.crop));
            
        }
    }
    

    [System.Serializable]
    public class CropSpaceData
    {
        public int crop;
        
        
    }
}
