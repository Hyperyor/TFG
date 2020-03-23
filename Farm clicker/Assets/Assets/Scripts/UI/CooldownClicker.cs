using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Crops;

namespace Idle {

	/// <summary>
	/// A clicker that has a cool down.
	/// </summary>
	public class CooldownClicker : MonoBehaviour {

		/// <summary>
		/// How long it takes to cool down this clicker in seconds.
		/// </summary>
		[Tooltip ("How long it takes to cool down this clicker in seconds.")]
		[SerializeField]
		protected float coolDownTime;

		/// <summary>
		/// Current cool down time. 0 means ready to go.
		/// </summary>
		protected float coolDownTimer;

		/// <summary>
		/// Stores the cool down time as time span in order to support reloading of app.
		/// </summary>
		//protected long coolDownExpiryTime;


		[Tooltip ("Filled image to use for the cool down indicator.")]
		[SerializeField]
		protected Image image;

        private bool working;

		//void Awake() {
		//	Load (this);
		//}

		void Start() {
			if (image == null) image = GetComponent<Image> ();
			if (image == null) Debug.LogWarning ("CooldownClicker has no image assigned.");
			image.fillAmount = CoolDownPercentage;
#if UNITY_EDITOR
			// Check to see if multiple cool down clickers have the same name and click name, this will cause issues with persistence.
			//CooldownClicker[] cdcs = FindObjectsOfType<CooldownClicker>();
			//foreach (CooldownClicker cdc in cdcs) {
			//	if (cdc != this && cdc.clickName == this.clickName && cdc.gameObject.name == this.gameObject.name) {
			//		Debug.LogWarning("Cool down clickers with the same click name must have different GameObject names ot else their state cannot be saved properly.");
			//	}
			//}
#endif
		}

		void Update() {

            if(working)
            {
                if (image.fillAmount > 0)
                {
                    coolDownTimer -= Time.deltaTime;
                    //image.fillAmount = CoolDownPercentage;
                    image.fillAmount -= 1.0f / coolDownTime * Time.deltaTime;

                    if(image.fillAmount > 0.75f) 
                    {
                        gameObject.GetComponent<CropSpace>().ChangeCropState(0);
                    }
                    else
                    {
                        if(image.fillAmount < 0.75f && image.fillAmount > 0.50f)
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

        public void StartTimer()
        {
            image.fillAmount = 1.0f ;

            image.gameObject.SetActive(true);

            working = true;

            coolDownTimer = coolDownTime;

            
        }

        public void ResetTimer()
        {
            if(image.fillAmount <= 0)
            { 
                gameObject.GetComponent<CropSpace>().ChangeCropState(0);
                image.fillAmount = 1.0f;
                working = true;

            }
        }

        /// <summary>
        /// Gets the cool down time as a percentage value between 0 and 1.
        /// </summary>
        /// <value>The cool down percentage (o to 1).</value>
        public float CoolDownPercentage {
			get {
				return 1.0f - (coolDownTimer / coolDownTime);
			}
		}

		/// <summary>
		/// Attach the UI click event to this to do a click.
		/// </summary>
		//override public void Click() {
		//	if (coolDownTimer <= 0) {
		//		ClickManager.GetInstance (clickName).AddClicks (ClickManager.GetInstance(clickName).ClickIncrement);
		//		coolDownTimer = coolDownTime;
		//		coolDownExpiryTime = (System.DateTime.Now + System.TimeSpan.FromSeconds(coolDownTime)).ToBinary();
		//		Save(this);
		//	}
		//}


#region Persistable

		///// <summary>
		///// Gets the unique save key.
		///// </summary>
		//override public string UniqueSaveKey {
		//	get {
		//		return "Data_CooldownClicker_" + clickName + "_" + gameObject.name;
		//	}
		//}

		///// <summary>
		///// Gets the save data.
		///// </summary>
		///// <value>The save data.</value>
		//override public object SaveData {
		//	get {
		//		return new object[] {coolDownExpiryTime};
		//	}
		//	set {
		//		coolDownTimer = 0;
		//		if (value.GetType () == SavedObjectType) {
		//			coolDownExpiryTime = (long)((object[])value) [0];
		//			System.TimeSpan remaining = System.DateTime.FromBinary (coolDownExpiryTime) - System.DateTime.Now;
		//			if  (remaining.TotalSeconds > 0) {
		//				// We lose up to 1 second due to rounding, but given it requires an app restart it should be fine
		//				coolDownTimer = (float)remaining.TotalSeconds;
		//			}
		//		}
		//	}
		//}

		///// <summary>
		///// Get the type of object this Persistable saves.
		///// </summary>
		//override public System.Type SavedObjectType {
		//	get {
		//		return typeof(object[]);
		//	}
		//}

		//override public void PostResetAction() {
		//	coolDownTimer = 0;
		//	coolDownExpiryTime = 0;
		//	base.PostResetAction ();
		//}

#endregion

	}

}
