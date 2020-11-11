using UnityEngine;

namespace Core
{
    public class UpgradeManager : MonoBehaviour
    {

        [Header("Components")]
        public ClickUpgrade clickUpgrade;
        public AutomationUpgrade automationUpgrade;

        private void Awake()
        {
            //load saves from file
            UpgradeLoad();
        }

        ////////////////////////////////// Start: Calls upgrades from buttons
        public void ClickUpgrade(int itemId)
        {
            clickUpgrade.UpgradeItem(itemId); //Call the upgrade method in the click Upgrade script (whose ID item is the upgrade)
        }
        
        public void AutomationUpgrade(int itemId)
        {
            automationUpgrade.UpgradeItem(itemId);
        }
        ////////////////////////////////// End


        //Update UI
        public void UpdateUI()
        {
            clickUpgrade.UpdateUI();
            
            //automationUpgrade.UpdateUI();
        }

        //saving upgrade data to file
        public void UpgradeSave()
        {
            //We clear the list of all items, in order to avoid writing
            UpgradeListClear();

            //Write items to the cleared list
            for (int i = 0; i < clickUpgrade.models.Count; i++)
            {
                DataManager.upgradeData.clickItems.Add(clickUpgrade.models[i].priceData);
            }
            

            //save all data
            DataManager.SaveData();
        }
        //load data
        public void UpgradeLoad()
        {
            if(DataManager.upgradeData.clickItems.Count > 0)
            {
                //write item from file to item on scene
                for (int i = 0; i < DataManager.upgradeData.clickItems.Count; i++)
                {
                    clickUpgrade.models[i].priceData = DataManager.upgradeData.clickItems[i];
                }
            }

            UpdateUI();
            
        }

        //Сlear method
        void UpgradeListClear()
        {
            DataManager.upgradeData.clickItems.Clear();
        }
    }
}