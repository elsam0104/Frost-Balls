using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    List<Color> colors = new List<Color>();
    Color taggedColor = Color.blue;
    MeshRenderer mesh;
    bool isTagged = false;
    public bool IsTagged { get { return isTagged; } set { isTagged = value; } }
    private void Start()
    {
        FindObjectOfType<DeformPlane>().DeformMesh(transform.position);
        mesh = GetComponent<MeshRenderer>();
        taggedColor = colors[Random.Range(0, colors.Count)];
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            if (isTagged)
            {
                Ball otherBall = collision.gameObject.GetComponent<Ball>();
                otherBall.IsTagged = true;
                otherBall.mesh.material.color = otherBall.taggedColor;
            }
            else
            {
                isTagged = true;
                mesh.material.color = taggedColor;
            }
        }
    }
}
