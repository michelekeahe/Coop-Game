using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fov : MonoBehaviour
{
    public float viewDistance = 0f;


    void Update()
    {

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;


        float fov = 90f;
        int raycount = 10;
        float angle = 0f;
        float angleIncreae = fov / raycount;
        Vector3 origin = Vector3.zero;

        Vector3[] vertices = new Vector3[raycount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] trianglePoints = new int[raycount * 3];


        vertices[0] = origin;

        int vertextIndex = 1;
        int triangleIndex = 0;
        for(int i = 0; i <= raycount; i++)
        {
            Vector3 vertex;

            RaycastHit2D hit = Physics2D.Raycast(origin, AngleToVector(angle),  viewDistance);
            Debug.DrawRay(origin, AngleToVector(angle) * viewDistance, Color.red);

            if (hit.collider == null)
            {
                //No hit
                vertex = origin + AngleToVector(angle) * viewDistance;
            }
            else
            {
                //Hit object
                vertex = hit.point;
            }

            vertices[vertextIndex] = vertex;

            if(i > 0)
            {
                trianglePoints[triangleIndex + 0] = 0;
                trianglePoints[triangleIndex + 1] = vertextIndex - 1;
                trianglePoints[triangleIndex + 2] = vertextIndex;

                triangleIndex += 3;
            }

            vertextIndex++;
            angle -= angleIncreae;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = trianglePoints;

    }



   private Vector3 AngleToVector(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
