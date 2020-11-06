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
        public int price;

        public void UpgradePrice()
        {
            if(price < 300000)
            {
                price += price * ((int)3);
            }
            
        }

    }
}
