using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fov : MonoBehaviour
{
    #region Components
    private Mesh mesh;
    [SerializeField] private LayerMask layerMask;
    #endregion

    #region SerializedFeild
    [SerializeField] private float viewDistance = 0f;
    [SerializeField] private float fov = 90f;
    [SerializeField] private int raycount = 10;
    #endregion

    #region Private Var
    private float startingAngle;
    private Vector3 origin;
    #endregion

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
    }

    //Draws the FOV mesh according to rays
    private void LateUpdate()
    {
        mesh.RecalculateBounds();
        float angle = startingAngle;
        float angleIncreae = fov / raycount;

        Vector3[] vertices = new Vector3[raycount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] trianglePoints = new int[raycount * 3];


        vertices[0] = origin;

        int vertextIndex = 1;
        int triangleIndex = 0;
        for(int i = 0; i <= raycount; i++)
        {
            Vector3 vertex;

            RaycastHit2D hit = Physics2D.Raycast(origin, AngleToVector(angle),  viewDistance, layerMask);
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

    // Fancy method to turn a float to a vector
   private Vector3 AngleToVector(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    // PlayerCombat script sends origin point (that is, the gun) to this script
    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    // PlayerCombat script sends mouse direction to this script
    public void SetAimDir(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) + fov / 2;
    }

    // Fancy method to turn vector to a float
    public float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
}
