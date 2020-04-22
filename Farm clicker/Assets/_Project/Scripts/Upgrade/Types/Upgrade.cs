using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Upgrade : MonoBehaviour
    {
        [Header("Components")]
        public List<UpgradeItem> items = new List<UpgradeItem>();
        protected bool priced;

        //Base method is responsible for the purchase of the upgrade
        public virtual void UpgradeItem(int id)
        {
            //The condition of checking for money
            if (DataManager.data.Money >= items[id].itemData.price)
            {
                //With a successful purchase
                DataManager.data.Money -= items[id].itemData.price; //take money
                items[id].itemData.price = items[id].itemData.price * 2; //Increasing the price by 2
                priced = true; //this means we CAN upgrade the item
            }
        }

        //The method is responsible for the successful purchase, makes saving
        protected void Upgraded()
        {
            priced = false;
            UpdateUI();
            Managers.Instance.uIManager.UpdateUI();

            Managers.Instance.upgradeManager.UpgradeSave();
        }

        //Update UI
        public void UpdateUI()
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].UpdateUI();
            }
        }
    }
}