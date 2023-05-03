using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformPlane : MonoBehaviour
{
    MeshFilter meshFilter;
    Mesh planeMesh;
    Vector3[] verts;
    [SerializeField]
    float radius = 0f;
    [SerializeField]
    float power = 0f;
    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        planeMesh = meshFilter.mesh;
        verts = planeMesh.vertices;
    }
    public void DeformMesh(Vector3 posToDeform)
    {
        posToDeform = transform.InverseTransformPoint(posToDeform);
        for (int i = 0; i < verts.Length; i++)
        {
            float dist = (verts[i]-posToDeform).sqrMagnitude;

            if(dist <radius)
            {
                verts[i] -= Vector3.up * power;
            }
        }
        planeMesh.vertices = verts;
    }
}
