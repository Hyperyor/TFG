using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crops
{

    public class CropsManager : MonoBehaviour
    {
        [SerializeField]
        private Crop[] cropsList = new Crop[7];

        public Crop GetCropAt(int index)
        {
            return cropsList[index];
        }

        public void AddPrice(int index, int p)
        {
            cropsList[index].AddPrice(p);
        }

        public void AddBenefits(int index, int b)
        {
            cropsList[index].AddBenefits(b);
        }
    }
}
