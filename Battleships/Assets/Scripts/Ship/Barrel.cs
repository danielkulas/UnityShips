/*Daniel Kulas*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ship
{
    public class Barrel : MonoBehaviour
    {
       void Update()
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }
}