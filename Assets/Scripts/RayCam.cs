using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    Vector3 lastPos;

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
        if ((lastPos - Input.mousePosition).sqrMagnitude <= 2) return;
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out Hit))
        {
            if (Hit.collider.tag == "Background")
                return;
            //deform mesh
            Collider[] colliders = Physics.OverlapSphere(Hit.point, 5f);
            Collider deformCol = colliders.FirstOrDefault(collider => collider.GetComponent<DeformPlane>() != null);
            //DeformPlane deformPlane = Hit.transform.GetComponent<DeformPlane>();
            if (deformCol != null)
            {
                Vector3 hitPoint = new Vector3(Hit.point.x, Hit.point.y, 0);
                deformCol?.GetComponent<DeformPlane>().DeformMesh(hitPoint);
            //if (Hit.collider.tag != "RingBlock")
                //Instantiate(ringPrefab, new Vector3(Hit.point.x, Hit.point.y, 0.066f), Quaternion.Euler(-90f, 0f, 0f));
            }

            //{
            //    Destroy(Hit.collider.gameObject);
            //}
        }

        lastPos = Input.mousePosition;
    }
}
