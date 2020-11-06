using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Core
{
    public abstract class UpgradeItem : MonoBehaviour
    {
        //[Header("Components")]
        //public UpgradeItemData itemData;

 
        [Header("UI")]
        public Image iconImage, priceImage;
        public Text nameText, descriptionText, priceText;
        public Button buyBtn;
        public Image tooExpensiveImage;

        //public ActionType tipo { get { return ActionType.CLICKUPGRADE; } }

        //Method for update UI
        public void UpdateUI(UpgradeItemModel model)
        {
            iconImage.sprite = model.icon;
            nameText.text = model.upgradeName;
            descriptionText.text = model.description + ": " + model.value + "$";
            priceText.text = ":" + UIManager.IntParseToString(model.price) + "$";

            UpdateUI();
        }

        //abstract method that children will implement so they can make different things with the same base
        public abstract void MakeUpgrade(UpgradeItemModel model);

        public abstract void UpdateUI();

        //public void CanBuy(bool val)
        //{
        //    if (val)
        //    {
        //        tooExpensiveImage.gameObject.SetActive(false);
        //        buyBtn.GetComponent<Button>().enabled = true;
        //    }
        //    else
        //    {
        //        tooExpensiveImage.gameObject.SetActive(true);
        //        buyBtn.GetComponent<Button>().enabled = false;
        //    }

        //}

    }

    //The class that stores the data to save the Item
    //[Serializable]
    //public class UpgradeItemData
    //{
    //    public long price;
    //}
}
