using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour
{
    [SerializeField]
    MeshCollider[] m_Colliders;
    private void Start()
    {
        foreach (var collider in m_Colliders) { collider.enabled = true; }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "RingBlock")
        {
            Destroy(other.gameObject);
        }
    }

}
