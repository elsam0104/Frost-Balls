using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCam : MonoBehaviour
{
    Ray ray;
    RaycastHit Hit;

    Camera cam;

    [SerializeField]
    Transform ringPrefab;
    [SerializeField]
    DeformPlane plane;
    private void Start()
    {
        cam = transform.GetComponent<Camera>();
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            DeformMesh();
        }
    }
    private void DeformMesh()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out Hit))
        {
            //deform mesh
            //DeformPlane deformPlane = Hit.transform.GetComponent<DeformPlane>();
            if (Hit.collider.tag == "sand")
            {
                plane.DeformMesh(Hit.point);
                Instantiate(ringPrefab, new Vector3(Hit.point.x, Hit.point.y, Hit.point.z + 0.066f), Quaternion.Euler(-90f, 0f, 0f));
            }
        }
    }
}
