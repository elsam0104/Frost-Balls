using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformArea : MonoBehaviour
{
    [SerializeField]
    float radius = 2f;
    [SerializeField]
    GameObject ringPrefab;
    void Start()
    {
        FindObjectOfType<DeformPlane>().DeformMesh(transform.position, radius);
        FindObjectOfType<DeformPlane>().DeformMesh(transform.position, radius);
        FindObjectOfType<DeformPlane>().DeformMesh(transform.position, radius);
        //Instantiate(ringPrefab, new Vector3(transform.position.x, transform.position.y, 0.066f), Quaternion.Euler(-90f, 0f, 0f));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.tag == "RingBlock")
        {
            Destroy(other.gameObject);
        }
    }

}
