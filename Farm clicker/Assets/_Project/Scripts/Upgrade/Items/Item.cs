using UnityEngine;
using UnityEngine.UI;
using System;

namespace Core
{
    public class Item : MonoBehaviour
    {
        [Header("Components")]
        public ItemData itemData;

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

        //Method for update UI
        public void UpdateUI()
        {
            iconImage.sprite = icon;
            nameText.text = itemName;
            descriptionText.text = description + ": " + value;
            priceText.text = ":" + UIManager.IntParseToString(itemData.price);
        }

        public void CanBuy(bool val)
        {
            if(val)
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
    public class ItemData
    {
        public long price;
    }

}