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
        private int unlockPrice;

        [SerializeField]
        private int linesUnlocked;

        [SerializeField]
        private Button unlockButton;

        private void Awake()
        {
            UpdateButtonText();
        }

        private void UpdateButtonText()
        {
            unlockButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Buy Harvest Line: " + unlockPrice + "$";
        }

        public void UnlockLine()
        {
            if(CanUnlock())
            {
                harvestLineList[linesUnlocked].gameObject.SetActive(true);
                linesUnlocked++;

                Managers.Instance.gameManager.Buy(unlockPrice);

                if(linesUnlocked == 7)
                {
                    unlockButton.gameObject.SetActive(false);
                }
            }
        }

        private bool CanUnlock()
        {
            if(linesUnlocked <= 6) //is there are some still lines unlocked
            {
                if(DataManager.data.Money >= unlockPrice)
                {
                    return true;
                }
            }


            return false;
        }
    }
}


