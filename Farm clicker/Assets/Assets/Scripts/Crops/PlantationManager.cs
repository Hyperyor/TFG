using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Idle
{
    
    public class PlantationManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject cropsMenu;

        //Method to show crops options
        public void ShowCropsOptions(int id)
        {
            cropsMenu.SetActive(true);
        }

        public void HideCropsOptions()
        {
            cropsMenu.SetActive(false);
        }
    }
}
