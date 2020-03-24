using UnityEngine;
using Crops;

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
        }
        #endregion

        private void Awake()
        {
            //Sigleton init befor scene load
            Init();
        }

    }
}