using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Core
{

    public class MoneyPerClick : UpgradeItem
    {
        public TextMeshProUGUI upgradeBonusText; 

        public override void MakeUpgrade(UpgradeItemModel model)
        {
            if(DataManager.data.MoneyByClick < 3000)
            {
                DataManager.data.MoneyByClick += model.value;
                model.UpgradePrice();
                
            }
            
        }

        public override void UpdateUI()
        {
            upgradeBonusText.text = "Bonus x" + DataManager.data.MoneyByClick;
        }
    }
}
