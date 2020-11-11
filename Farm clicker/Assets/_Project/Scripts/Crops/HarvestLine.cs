using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Crops
{

    public class HarvestLine : MonoBehaviour
    {
        [SerializeField]
        public CropSpace[] cropSpaceList = new CropSpace[3];

        public HarvestLineData data;

        public void LoadCropSpace(HarvestLineData dat)
        {
            //take data from file
            data = dat;
            //send loaded data to cropsspaces

            for (int i = 0; i < data.crops.Count; i++)
            {
                if (data.crops[i].crop != -1)
                {
                    cropSpaceList[i].cropSpaceData = data.crops[i];

                    cropSpaceList[i].LoadCropSpaceData();
                }
                
            }
            

        }

        public void SaveHarvestLineData()
        {
            data.crops.Clear();

            for (int i = 0; i < cropSpaceList.Length; i++)
            {
                
                data.crops.Add(cropSpaceList[i].cropSpaceData);
            }
        }
        
    }

    [System.Serializable]
    public class HarvestLineData
    {
        public List<CropSpaceData> crops = new List<CropSpaceData>();
    }
}


