using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{

    public class MoneyPerClick : UpgradeItem
    {
        public override void MakeUpgrade(UpgradeItemModel model)
        {
            DataManager.data.MoneyByClick += model.value;
        }
    }
}
