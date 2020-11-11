using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Crops;

namespace Core {

    //original author: JNA Mobile (http://jnamobile.com) //Modified by: Jose Luis Bernal Navarrete
    public class CooldownClicker : MonoBehaviour
    {
        
        protected float coolDownTime;
        
        protected float coolDownTimer;
        

        [Tooltip("Filled image to use for the cool down indicator.")]
        [SerializeField]
        public Image image;

        private bool working;

        //void Awake()
        //{
        //    if (image == null) image = GetComponent<Image>();
        //    if (image == null) Debug.LogWarning("CooldownClicker has no image assigned.");
        //    image.fillAmount = CoolDownPercentage;
        //}

        void Start()
        {
            if (image == null) image = GetComponent<Image>();
            if (image == null) Debug.LogWarning("CooldownClicker has no image assigned.");
            image.fillAmount = CoolDownPercentage;

        }

        void Update()
        {

            if (working)
            {
                if (image.fillAmount > 0)
                {
                    //coolDownTimer -= Time.deltaTime;
                    //image.fillAmount = CoolDownPercentage;
                    image.fillAmount -= 1.0f / coolDownTime * Time.deltaTime;

                    if (image.fillAmount > 0.75f)
                    {
                        gameObject.GetComponent<CropSpace>().ChangeCropState(0);
                    }
                    else
                    {
                        if (image.fillAmount < 0.75f && image.fillAmount > 0.50f)
                        {
                            gameObject.GetComponent<CropSpace>().ChangeCropState(1);
                        }
                        else
                        {
                            gameObject.GetComponent<CropSpace>().ChangeCropState(2);
                        }
                    }
                }
                else
                {
                    gameObject.GetComponent<CropSpace>().ChangeCropState(3);
                    working = false;
                }

            }

        }

        public void ShutDown()
        {
            image.fillAmount = 1.0f;

            image.gameObject.SetActive(false);

            working = false;
        }

        public float CD
        {
            get
            {
                return coolDownTime;
            }

            set
            {
                coolDownTime = value;
            }
        }

        public void StartTimer()
        {

            image.fillAmount = 1.0f;

            image.gameObject.SetActive(true);

            working = true;

            coolDownTimer = coolDownTime;


        }

        public void ResetTimer()
        {
            if (image.fillAmount <= 0)
            {
                Managers.Instance.gameManager.CropHarvested(gameObject.GetComponent<CropSpace>().GetPlantedCrop().Benefits);
                gameObject.GetComponent<CropSpace>().ChangeCropState(0);
                image.fillAmount = 1.0f;
                working = true;

            }
        }

        /// <summary>
        /// Gets the cool down time as a percentage value between 0 and 1.
        /// </summary>
        /// <value>The cool down percentage (o to 1).</value>
        public float CoolDownPercentage
        {
            get
            {
                return 1.0f - (coolDownTimer / coolDownTime);
            }
        }


    }

    
}
