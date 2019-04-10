/*Daniel Kulas*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ship
{
    public class Drifting : MonoBehaviour
    {
        public float frequency = 2.0f;
        public float height = 6.0f;
        float time;


        void Start()
        {
            time = 0.0f;
        }

        void FixedUpdate()
        {
            time += Time.deltaTime;
            drift();
        }

        void drift()
        {
            float x = transform.eulerAngles.x;
            //float x = Mathf.Sin(frequency * time) * height;

            float y = transform.eulerAngles.y;
            //float y = Mathf.Cos(frequency * time) * height;

            //float z = transform.eulerAngles.z;
            float z = Mathf.Cos(frequency * time) * height;

            transform.eulerAngles = new Vector3(x, y, z);
        }
    }
}