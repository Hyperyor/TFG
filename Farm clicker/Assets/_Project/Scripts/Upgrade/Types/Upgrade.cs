using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Upgrade : MonoBehaviour
    {
        [Header("Components")]
        public List<UpgradeItem> items = new List<UpgradeItem>();
        public List<UpgradeItemModel> models = new List<UpgradeItemModel>();
        protected bool priced;

        //Base method is responsible for the purchase of the upgrade
        public virtual void UpgradeItem(int id)
        {
            //The condition of checking for money
            if (DataManager.data.Money >= models[id].priceData.price)
            {
                //With a successful purchase
                DataManager.data.Money -= models[id].priceData.price; //take money
                Managers.Instance.audioManager.PlaySound(Managers.Instance.audioManager.cash); //play a sound
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
        public void UpdateUI() //check this inefficient shit and change it if possible
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].UpdateUI(models[i]);
            }
        }
    }
}