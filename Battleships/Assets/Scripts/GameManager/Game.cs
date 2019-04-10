/*Daniel Kulas*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Ship
{
    public class Game : MonoBehaviour
    {
        public Transform shipOne;
        public Transform shipTwo;
        public Transform winUI;
        public Text text;
        public Vector3 shipOnePos;
        public Vector3 shipTwoPos;
        public int maxScore;
        int shipOneResult = 0;
        int shipTwoResult = 0;


        void Start()
        {
            shipOne.transform.position = shipOnePos;
            shipTwo.transform.position = shipTwoPos;
            text.text = shipOneResult + " : " + shipTwoResult;
        }

        public void shipWasHit(string shipName)
        {
            Transform Ship = shipOne;
            if (shipName == "Ship1")
            {
                Ship = shipOne;
                shipTwoResult++;
            }
            else if (shipName == "Ship2")
            {
                Ship = shipTwo;
                shipOneResult++;
            }
            text.text = shipOneResult + " : " + shipTwoResult;
            Ship.GetComponent<Sounds>().getExplosionSound();

            Ship.Find("ParticleSystem").Find("HittedPS").gameObject.SetActive(true);
            shipOne.GetComponent<Movement>().enabled = false;
            shipOne.GetComponent<Shooting>().enabled = false;

            shipTwo.GetComponent<Movement>().enabled = false;
            shipTwo.GetComponent<Shooting>().enabled = false;

            if (shipOneResult >= maxScore || shipTwoResult >= maxScore)
                onWin();
            else
                Invoke("waitAndSet", 5.0f);
        }

        void waitAndSet()
        {
            shipOne.transform.position = shipOnePos;
            shipOne.GetComponent<Movement>().enabled = true;
            shipOne.GetComponent<Shooting>().enabled = true;
            shipOne.Find("ParticleSystem").Find("HittedPS").gameObject.SetActive(false);

            shipTwo.transform.position = shipTwoPos;
            shipTwo.GetComponent<Movement>().enabled = true;
            shipTwo.GetComponent<Shooting>().enabled = true;
            shipTwo.Find("ParticleSystem").Find("HittedPS").gameObject.SetActive(false);
        }

        void onWin()
        {
            winUI.gameObject.SetActive(true);
        }
    }
}