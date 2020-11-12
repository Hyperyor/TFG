using UnityEngine;
using Crops;
using Firebase;
using Firebase.Analytics;
using System;

namespace Core
{
    public sealed class Managers : MonoBehaviour
    {
        //Singleton
        public static Managers Instance;

        //Component List
        [Header("Components")]
        public AnimatorManager animatorManager;
        public UIManager uIManager;
        public GameManager gameManager;
        public ParticleManager particleManager;
        public UpgradeManager upgradeManager;
        public AudioManager audioManager;
        public PlantationManager plantationMan;
        public CropsManager cropsMan;

        #region //Singleton init method
        void Init()
        {
            if (Instance != null)
                Destroy(gameObject);

            Instance = this;

            try
            {


                FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
                {
                    FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
                }
                );

                
            }
            catch (Exception firebaseEx)
            {
                Debug.Log("Firebase falla");
            }

            try
            {
                FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLogin);
            }
            catch(Exception loginex)
            {
                Debug.Log("Error al logear");
            }

        }
        #endregion

        private void Awake()
        {

            //Sigleton init before scene load
            Init();
        }

    }
}