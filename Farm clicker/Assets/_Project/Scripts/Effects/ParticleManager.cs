using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ParticleManager : MonoBehaviour
    {
        [Header("Particle")]
        public ParticleSystem clickEffect;

        public Canvas canvas;

        // Method of playing effect, accepts any effect from cached
        public void PlayEffect(ParticleSystem particleSystem)
        {
            GameObject particle = Instantiate(particleSystem.gameObject); //Create the effect on scene
            //particle.transform.parent = Camera.main.transform; //Put it under the parent
            particle.transform.SetParent(canvas.transform);// = canvas.transform;
            particle.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            particle.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            particleSystem.Play(); //Play
        }
    }
}