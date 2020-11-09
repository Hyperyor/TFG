using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class MoneyPerSecond : UpgradeItem
    {
        public override void MakeUpgrade(UpgradeItemModel model)
        {
            if (DataManager.data.MoneyPerSecond < 3000)
            {
                DataManager.data.MoneyPerSecond += model.value;
                model.UpgradePrice();

            }
        }

        public override void UpdateUI()
        {
            //throw new System.NotImplementedException();
        }

        
    }
}
