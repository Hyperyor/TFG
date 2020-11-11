using Crops;
using UnityEngine;

namespace Core
{
    public class DataManager : MonoBehaviour
    {
        //Components
        static DataSaver dataSaver;

        public static Data data;
        public static UpgradeData upgradeData;
        public static PlantationData plantationData;

        private void Awake()
        {
            Init();
        }

        void Init()
        {
            //Create an instance of classes
            data = new Data();
            upgradeData = new UpgradeData();
            plantationData = new PlantationData();

            //Cached component from our Gameobject
            dataSaver = GetComponent<DataSaver>();

            LoadData();
            

            //We make the first launch, and give the starter kit
            if (!data.isFirstStartComplete)
            {
                data.isFirstStartComplete = true;

                data.Money = 10;
                data.MoneyByClick = 1;
                plantationData.linesUnlocked = 0;
                plantationData.unlockPrice = 150;

                SaveData();
            }

        }

        //Static save method, can be called from any class "DataManager.SaveData();"
        public static void SaveData()
        {
            object[] obj = new object[3]; // Create a local variable for an array of objects
            //register the objects we need
            obj[0] = data;
            obj[1] = upgradeData;
            obj[2] = plantationData;

            dataSaver.Save(obj); //Save to DataSaver
        }

        //Static load method, can be called from any class "DataManager.LoadData();"
        public static void LoadData()
        {
            

            object[] obj = dataSaver.Load();  //Get the data array from the file
            //We assign the objects we need
            if (obj != null)
            {
                data = obj[0] as Data;
                upgradeData = obj[1] as UpgradeData;
                plantationData = obj[2] as PlantationData;
            }

        }

    }

}
