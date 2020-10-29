﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField]
        private ExitApp exit;

        //The method is invoked by tapping the screen
        public void Click()
        {
            DataManager.data.Money += DataManager.data.MoneyByClick; //add money by tap
            //StartCoroutine(CameraShake.Shake(Camera.main.transform, 0.1f, 0.01f));  //play the effect of shaking
            MoneyGained();
        }

        public void CropHarvested(int money)
        {
            DataManager.data.Money += money;
            MoneyGained();
        }
        
        public void Buy(int money)
        {
            DataManager.data.Money -= money;
            Managers.Instance.uIManager.UpdateUI(); //Updating UI
            //play a sound
            Managers.Instance.audioManager.PlaySound(Managers.Instance.audioManager.cash);
        }

        private void MoneyGained()
        {
            Managers.Instance.particleManager.PlayEffect(Managers.Instance.particleManager.clickEffect);  //play the particle effect
            Managers.Instance.uIManager.UpdateUI(); //Updating UI
            Managers.Instance.audioManager.PlaySound(Managers.Instance.audioManager.Coin);//play sound
        }
        
        //Method to start the game
        public void StartGame()
        {
            Managers.Instance.uIManager.ChangeScreen("GameScreen");
            StartCoroutine(MoneyPerSecond());
        }
        //Method to pause
        public void Pause()
        {
            Managers.Instance.uIManager.ChangeScreen("PauseMenu");
        }

        //Method to show volume options
        public void VolumeOptions()
        {
            this.Pause(); //we hide/show the pause menu
            Managers.Instance.uIManager.ShowVolumeOptions();
        }

        public void ExitApp()
        {
            //save game

            //closing the app
            exit.Exit();
        }

        //The loop of adding money per second
        IEnumerator MoneyPerSecond()
        {
            yield return new WaitForSeconds(1); //WaitForSeconds(HERE HOW MANY SECONDS WAIT)

            DataManager.data.Money += DataManager.data.MoneyPerSecond;  //add money by second
            Managers.Instance.uIManager.UpdateUI();  //Updating UI
            DataManager.SaveData();  //Save data
            StartCoroutine(MoneyPerSecond());   //Repeat loop
        }
    }
}