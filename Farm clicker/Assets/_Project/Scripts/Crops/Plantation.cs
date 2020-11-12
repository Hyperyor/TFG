using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Core;

namespace Crops
{
    public class Plantation : MonoBehaviour
    {
        [SerializeField]
        private HarvestLine[] harvestLineList = new HarvestLine[7];
        

        [SerializeField]
        private Button unlockButton;

        private void Awake()
        {
            //UpdateButtonText();
        }

        private void UpdateButtonText()
        {
            unlockButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Buy Harvest Line: " + UIManager.IntParseToString(DataManager.plantationData.unlockPrice) + " $";
        }

        public void UnlockLine()
        {
            if(CanUnlock())
            {
                harvestLineList[DataManager.plantationData.linesUnlocked].gameObject.SetActive(true);
                DataManager.plantationData.linesUnlocked++;

                
                Managers.Instance.gameManager.Buy(DataManager.plantationData.unlockPrice);

                DataManager.plantationData.unlockPrice += (DataManager.plantationData.unlockPrice * ((int)2.5));
                UpdateButtonText();
                if (DataManager.plantationData.linesUnlocked == 7)
                {
                    unlockButton.gameObject.SetActive(false);
                }

                Managers.Instance.plantationMan.SavePlantationData();
            }
        }

        private bool CanUnlock()
        {
            if(DataManager.plantationData.linesUnlocked <= 6) //is there are some still lines unlocked
            {
                if(DataManager.data.Money >= DataManager.plantationData.unlockPrice)
                {
                    return true;
                }
            }


            return false;
        }

        public void LoadPlantationData()
        {
            UpdateButtonText();

            if (DataManager.plantationData.linesUnlocked == 7)
            {
                unlockButton.gameObject.SetActive(false);
            }
            
            for (int i = 0; i < DataManager.plantationData.linesUnlocked; i++)
            {
                harvestLineList[i].gameObject.SetActive(true);
                harvestLineList[i].LoadCropSpace(DataManager.plantationData.harvestLineList[i]);
            }
            
        }

        public void SavePlantationData()
        {
            for (int i = 0; i < harvestLineList.Length; i++)
            {
                harvestLineList[i].SaveHarvestLineData();
                DataManager.plantationData.harvestLineList.Add(harvestLineList[i].data);
            }
        }
    }

    

    
}


