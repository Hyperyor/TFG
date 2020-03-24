using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Core;
using UnityEngine;

namespace Crops
{
    
    public class Crop : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] states;

        [SerializeField]
        private int price;

        [SerializeField]
        private int benefits;

        public string itemName;

        public string description;
        
        public Sprite icon;

        [SerializeField]
        private float harvestTime;

        public int Benefits
        {
            get
            {
                return benefits;
            }

            set
            {
                benefits = value;
            }
        }

        public float HaversTime
        {
            get
            {
                return harvestTime;

            }

            set
            {
                harvestTime = value;
            }
        }


        public Sprite GetState(int pos)
        {
            return states[pos];
        }

        public int GetPrice()
        {
            return price;
        }

        public void AddPrice(int money)
        {
            price += money;
        }

        public void AddBenefits(int b)
        {
            benefits += b;
        }

    }
}
