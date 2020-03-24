using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

namespace Crops
{


    public class CropsMenu : MonoBehaviour
    {
        
        [SerializeField]
        public Item[] cropsList = new Item[5];

        public void CheckItems()
        {
            Crop element = Managers.Instance.cropsMan.GetCropAt(0);

            Item i = cropsList[0];

            i.descriptionText.text = element.description + element.Benefits.ToString() + "$";

            i.nameText.text = element.itemName;

            i.priceText.text = element.GetPrice().ToString() + "$";

            i.value = element.Benefits;

            i.itemData.price = element.GetPrice();

            i.description = element.description + element.Benefits.ToString() + "$";

            i.itemName = element.itemName;

            i.icon = element.icon;

            i.iconImage.sprite = element.icon;

            if (DataManager.data.Money < i.itemData.price)
            {
                i.CanBuy(false);
            }
            else
            {
                i.CanBuy(true);
            }

        }
        

        public Item GetCropAt(int pos)
        {
            return cropsList[pos];
        }
    }
}
