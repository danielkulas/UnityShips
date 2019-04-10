/*Daniel Kulas*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ship
{
    [RequireComponent(typeof(AudioSource))]
    public class Sounds : MonoBehaviour
    {
        AudioSource audioSource;
        public AudioClip engineSound;
        public AudioClip shootSound;
        public AudioClip explosionSound;
        bool engineIsRunning = false;


        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void startEngineSound()
        {
            if (engineIsRunning == false)
            {
                audioSource.clip = engineSound;
                audioSource.loop = true;
                audioSource.Play();
                engineIsRunning = true;
            }

        }

        public void stopEngineSound()
        {
            if (engineIsRunning == true)
            {
                audioSource.Stop();
                audioSource.loop = false;
                audioSource.clip = null;
                engineIsRunning = false;
            }
        }

        public void getShootSound()
        {
            audioSource.PlayOneShot(shootSound);
        }

        public void getExplosionSound()
        {
            audioSource.PlayOneShot(explosionSound);
        }
    }
}