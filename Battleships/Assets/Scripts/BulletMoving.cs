/*Daniel Kulas*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ship
{
    public class BulletMoving : MonoBehaviour
    {
        public float bulletSpeed = 7.5f;


        void Start()
        {
            Destroy(this.gameObject, 10.0f); //If bullet doesn't collide with other gameObject
        }

        void FixedUpdate()
        {
            transform.Translate(new Vector3(0, 0, bulletSpeed), Space.Self);
        }

        void OnCollisionEnter(Collision collision)
        {
            if (transform.name != "Bullet" + collision.transform.name) //If bullet collide Ship which fired this bullet - do nothing
            {
                if (collision.transform.tag == "Ship") //If bullet collide with the other Ship
                {
                    GameObject.Find("GameManager").GetComponent<Game>().shipWasHit(collision.transform.name);
                }

                Destroy(this.gameObject);
            }
        }
    }
}