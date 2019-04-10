/*Daniel Kulas*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMoving : MonoBehaviour
{
    public Transform Ship1;
    public Transform Ship2;
    private Camera MainCamera;
    public int minSize = 20;
    public float zoom = 2.0f;


    void Start()
    {
        MainCamera = transform.GetChild(0).gameObject.GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        //Moving
        //Camera look on the space between two Ships
        Vector3 cameraPos;
        cameraPos.x = (Ship1.transform.position.x + Ship2.transform.position.x) / 2;
        cameraPos.y = 0;
        cameraPos.z = (Ship1.transform.position.z + Ship2.transform.position.z) / 2;

        transform.position = cameraPos;


        //Zooming
        Transform[] Ship = { Ship1, Ship2 };
        float size = minSize;
        float distance = 0.0f;

        for(int i = 0; i < 2; i++) //Geting max distance between camera and the farthest Ship
        {
            if (Vector3.Distance(transform.position, Ship[i].transform.position) > distance)
                distance = Vector3.Distance(transform.position, Ship[i].transform.position) / zoom;
        }
        if (distance > size)
            size = distance;

        MainCamera.orthographicSize = size;
    }
}