using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{


    public class ClickUpgrade : Upgrade
    {
        //Base method is responsible for the purchase of the upgrade
        public override void UpgradeItem(int id)
        {
            base.UpgradeItem(id);
            if (!priced)
                return;

            /////////////////////////////////////////////// #Start
            //This is where the logic of the action is written, provided that we have purchased

            items[id].MakeUpgrade(models[id]);
            

            /////////////////////////////////////////////// #End

            Upgraded();//The method is responsible for the successful purchase, makes saving
        }
    }
}
