/*Daniel Kulas*/
using System;
using System.Collections;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
public class WaterGenerator : MonoBehaviour
{
    public Vector2 meshSize = new Vector2(100, 100); //Number of edges(x, y)
    Mesh mesh; //Genereted mesh
    Vector3[] vertices;
    int[] triangles;

    public float meshHeight = 0.1f;
    public float waveFrequency = 0.2f;
    public float waveLength = 0.00001f;


    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        makeMesh();
    }

    void Update()
    {
        updateVertices();
    }

    void makeMesh()
    {
        int noOfVertX = (int)meshSize.x + 1;
        int noOfVertZ = (int)meshSize.y + 1;
        int noOfVert = (int)meshSize.x * (int)meshSize.y * 2 * 3; //2 * 3 - number of vertices in every square(two triangles)
        vertices = new Vector3[noOfVert];
        triangles = new int[noOfVert];

        for (int i = 0, current = 0; i < noOfVertX * noOfVertZ; i++)
        {
            int x = i % noOfVertX;
            int y = 0;
            int z = i / noOfVertX;

            if (x != noOfVertX - 1 && z != noOfVertZ - 1)
            {
                vertices[current] = new Vector3(x, y, z);
                vertices[current + 1] = new Vector3(x, y, z + 1);
                vertices[current + 2] = new Vector3(x + 1, y, z);
                current += 3;
            }
            if (x != noOfVertX - 1 && z != 0)
            {
                vertices[current] = new Vector3(x, y, z);
                vertices[current + 1] = new Vector3(x + 1, y, z);
                vertices[current + 2] = new Vector3(x + 1, y, z - 1);
                current += 3;
            }
        }

        for (int i = 0; i < triangles.Length; i++)
            triangles[i] = i;

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    void updateVertices()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 v = vertices[i];
            v.y = 0.0f;

            float distance = Vector3.Distance(v, Vector3.zero);
            distance = (distance % waveLength) / waveLength;

            //Oscilate the wave height via sine to create a wave effect
            v.y = meshHeight * Mathf.Sin(Time.time * Mathf.PI * 2.0f * waveFrequency
            + (Mathf.PI * 2.0f * distance));

            vertices[i] = v;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        mesh.MarkDynamic();
    }
}