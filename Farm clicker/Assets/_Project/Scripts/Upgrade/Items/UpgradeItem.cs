using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Core
{
    public abstract class UpgradeItem : MonoBehaviour
    {
        [Header("Components")]
        public UpgradeItemData itemData;

        [Header("Item info")]
        public string itemName;
        public string description;
        public Sprite icon;

        [Header("UI")]
        public Image iconImage, priceImage;
        public Text nameText, descriptionText, priceText;
        public Button buyBtn;
        public Image tooExpensiveImage;

        [Header("Value to add")]
        public int value;

        //public ActionType tipo { get { return ActionType.CLICKUPGRADE; } }

        //Method for update UI
        public void UpdateUI()
        {
            iconImage.sprite = icon;
            nameText.text = itemName;
            descriptionText.text = description + ": " + value;
            priceText.text = ":" + UIManager.IntParseToString(itemData.price);
        }

        //abstract method that children will implement so they can make different things with the same base
        public abstract void MakeUpgrade();

        public void CanBuy(bool val)
        {
            if (val)
            {
                tooExpensiveImage.gameObject.SetActive(false);
                buyBtn.GetComponent<Button>().enabled = true;
            }
            else
            {
                tooExpensiveImage.gameObject.SetActive(true);
                buyBtn.GetComponent<Button>().enabled = false;
            }

        }

    }

    //The class that stores the data to save the Item
    [Serializable]
    public class UpgradeItemData
    {
        public long price;
    }
}
