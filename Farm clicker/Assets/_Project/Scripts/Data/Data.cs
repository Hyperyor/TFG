using Crops;
using System;
using System.Collections.Generic;

namespace Core
{
    //This class is used to store the data
    [Serializable]
    public class Data
    {
        public bool isFirstStartComplete;

        public long Money;
        public long MoneyByClick;
        public long MoneyPerSecond;
    }

    [Serializable]
    public class UpgradeData
    {
        public List<UpgradeItemData> clickItems = new List<UpgradeItemData>();
        
    }

    [System.Serializable]
    public class PlantationData
    {
        public int unlockPrice;
        public int linesUnlocked;

        public List<HarvestLineData> harvestLineList = new List<HarvestLineData>();
    }


}
