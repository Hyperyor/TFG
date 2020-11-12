using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    [System.Serializable]
    public class UpgradeItemModel : MonoBehaviour
    {
        
        [Header("Upgrade info")]
        public string upgradeName;
        public string description;
        public Sprite icon;
        

        [Header("Value to add")]
        public int value;

        [Header("Price it costs")]
        //public int price;
        public UpgradeItemData priceData;


        public void UpgradePrice()
        {
            if(priceData.price < 300000)
            {
                priceData.price += priceData.price * ((int)3);
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
