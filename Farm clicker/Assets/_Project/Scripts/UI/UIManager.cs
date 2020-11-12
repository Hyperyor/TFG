﻿using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public sealed class UIManager : MonoBehaviour
    {
        //enum
        public enum ShopScreenType { Closed, ClickScreen, AutomationScreen }

        [Header("Screens")]
        public GameObject ClickScreen;
        public GameObject AutomationScreen;
        public GameObject volumeOptions;

        [Header("Text")]
        public Text MoneyText;
        public Text MoneyPerSecondText;


        ShopScreenType shopScreenType;        //Enum for tracking open store type
        bool isPause;                         //Check pause status

        private void Start()
        {
            UpdateUI();
        }

        //Update UI Total
        public void UpdateUI()
        {
            //Assign text
            MoneyText.text = IntParseToString(DataManager.data.Money);
            MoneyPerSecondText.text = "+" + IntParseToString(DataManager.data.MoneyPerSecond) + " /s";


            //Update upgrades UI
            Managers.Instance.upgradeManager.UpdateUI();

            //Save data to file
            DataManager.SaveData();
        }

        //Convert number to string with zero replaced by letters
        public static string IntParseToString(long value)
        {
            
            string result = value.ToString();

            if (value >= 1000)
            {
                result = Mathf.Floor(((float)value / 100)) / 10 + "k";
            }

            if (value >= 1000000)
            {
                result = Mathf.Floor(((float)value / 10000)) / 100 + "mi";
            }

            if (value >= 1000000000)
            {
                result = Mathf.Floor(((float)value / 10000000)) / 100 + "bi";
            }

            if (value >= 1000000000000)
            {
                result = Mathf.Floor(((float)value / 1000000000)) / 1000 + "qua";
            }

            return result;
        }

        #region //Shop
        //The method invokes the opening of the store
        public void ClickShop(string screenName)
        {
            switch (screenName)
            {
                case "ClickScreen":
                    //Call open method
                    ChangeShopScreen(ShopScreenType.ClickScreen);
                    break;
                case "AutomationScreen":
                    ChangeShopScreen(ShopScreenType.AutomationScreen);
                    break;
            }

        }

        public void ChangeShopScreen(ShopScreenType shopScreenType)
        {
            //If shopScreenType is equal to the same Screen that we ship, the store will be closed
            if (shopScreenType == this.shopScreenType)
            {
                //Calling a method to play an animation from AnimatorManager, by calling Singleton, store collapse animation
                Managers.Instance.animatorManager.PlayAnimation(Managers.Instance.animatorManager.shopAnimator, "ShopHide");
                //set the class variable shopScreenType to closed
                this.shopScreenType = ShopScreenType.Closed;
            }
            else
            {
                //Call the method of closing all screens for further replacement.
                CloseShopScreens();
                switch (shopScreenType)
                {
                    case ShopScreenType.ClickScreen:
                        //set the class variable shopScreenType to local shopScreenType
                        this.shopScreenType = shopScreenType;
                        //Turn on the screen
                        ClickScreen.SetActive(true);
                        break;
                    case ShopScreenType.AutomationScreen:
                        this.shopScreenType = shopScreenType;
                        AutomationScreen.SetActive(true);
                        break;
                }

                //Store open animation
                Managers.Instance.animatorManager.PlayAnimation(Managers.Instance.animatorManager.shopAnimator, "ShopShow");
            }
        }

        //It is necessary to close all stores, previously called from ChangeShopScreen
        void CloseShopScreens()
        {
            //Just turn off all screens, nothing ordinary :)
            ClickScreen.SetActive(false);
            AutomationScreen.SetActive(false);
        }
        #endregion
        #region//Screens
        //Method for changing main screens
        public void ChangeScreen(string screenName)
        {
            switch (screenName)
            {
                case "GameScreen":
                    Managers.Instance.animatorManager.PlayAnimation(Managers.Instance.animatorManager.screensAnimator, "GameScreen");
                    break;

                case "PauseMenu":
                    if (!isPause)
                    {
                        Managers.Instance.animatorManager.PlayAnimation(Managers.Instance.animatorManager.screensAnimator, "PauseMenuShow");
                        isPause = true;
                    }
                    else
                    {
                        Managers.Instance.animatorManager.PlayAnimation(Managers.Instance.animatorManager.screensAnimator, "PauseMenuHide");
                        isPause = false;
                    }
                    break;
            }
        }
        #endregion

        //method to show/hide volume settings menu
        public void ShowVolumeOptions()
        {
            if(volumeOptions.gameObject.activeInHierarchy)
            {
                //save volume data in json file
                Managers.Instance.audioManager.SaveVolumeData();
                //hide the volume menu
                volumeOptions.gameObject.SetActive(false);
            }
            else
            {
                volumeOptions.gameObject.SetActive(true);
            }
            
        }
    }
}