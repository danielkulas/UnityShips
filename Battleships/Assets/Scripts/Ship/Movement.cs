/*Daniel Kulas*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ship
{
    public class Movement : MonoBehaviour
    {
        public Transform Head;
        public Transform GameManager;
        public float ShipSpeed = 100.0f;
        public float topSpeed = 30.0f;
        public float ShipRotSpeed = 0.1f;
        public float headRotSpeed = 1.0f;
        Inputs input;
        Shooting shoot;
        Sounds sounds;
        Rigidbody rb;
        float inputSpeed;


        void Start()
        {
            input = GameManager.GetComponent<Inputs>();
            shoot = GetComponent<Shooting>();
            sounds = GetComponent<Sounds>();
            rb = GetComponent<Rigidbody>();

            rb.centerOfMass = new Vector3(0, -1.0f, 3.35f);
        }

        void FixedUpdate()
        {
            inputSpeed = 0.0f;

            if (transform.name == "Ship1")
            {
                inputSpeed = (input.inputTrigger.joy1 + input.inputTrigger.joy3) * ShipSpeed;
                float ShipRotation = (input.InputLeftXAxis.joy1 + input.InputLeftXAxis.joy3) * ShipRotSpeed * rb.velocity.magnitude;
                float headRotation = (input.InputRightXAxis.joy1 + input.InputRightXAxis.joy3) * headRotSpeed;
                //Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity); //Breaking

                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + ShipRotation, transform.eulerAngles.z); //Ship rotation
                Head.transform.eulerAngles = new Vector3(Head.transform.eulerAngles.x, Head.transform.eulerAngles.y + headRotation, Head.transform.eulerAngles.z); //Ship's head rotation
                if(rb.velocity.magnitude < topSpeed)  //transform.Translate(new Vector3(0, 0, speed), Space.Self);
                    rb.AddForce(transform.forward * inputSpeed);
            }
            else if (transform.name == "Ship2")
            {
                inputSpeed = input.inputTrigger.joy2 * ShipSpeed;
                float ShipRotation = input.InputLeftXAxis.joy2 * ShipRotSpeed * rb.velocity.magnitude;
                float headRotation = input.InputRightXAxis.joy2 * headRotSpeed;
                //Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity); //Breaking

                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + ShipRotation, transform.eulerAngles.z); //Ship rotation
                Head.transform.eulerAngles = new Vector3(Head.transform.eulerAngles.x, Head.transform.eulerAngles.y + headRotation, Head.transform.eulerAngles.z); //Ship's head rotation
                if (rb.velocity.magnitude < topSpeed)  //transform.Translate(new Vector3(0, 0, speed), Space.Self);
                    rb.AddForce(transform.forward * inputSpeed);
            }
        }

        void Update()
        {
            if (inputSpeed != 0)
            {
                transform.Find("ParticleSystem").Find("Water").GetComponent<ParticleSystem>().Play();
                sounds.startEngineSound();
            }
            else
            {
                transform.Find("ParticleSystem").Find("Water").GetComponent<ParticleSystem>().Stop();
                sounds.stopEngineSound();
            }

            if ((input.InputButtonX.joy1 == 1 && transform.name == "Ship1") || (input.InputButtonX.joy2 == 1 && transform.name == "Ship2"))
            {
                if (shoot.Shoot()) //If it was fired
                    sounds.getShootSound();
            }
        }
    }
}