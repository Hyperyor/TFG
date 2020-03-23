using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Idle;

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

        private Crop crop;

        private GameObject plantedCrop;

        public void Click()
        {
            manager.ShowCropsOptions(this);
        }

        public void SetCropImage(GameObject cropImg)
        {
            plantedCrop = Instantiate(cropImg); //crearemos una pool para esto

            plantedCrop.gameObject.transform.SetParent(this.transform);

            ChangeCropState(0);

            cropImage.gameObject.SetActive(true);

            this.gameObject.GetComponent<Button>().enabled = false;

            addText.enabled = false;

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
    }
}
