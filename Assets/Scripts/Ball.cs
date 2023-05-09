using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    List<Color> colors = new List<Color>();
    [SerializeField]
    bool isTagged = false;

    MeshRenderer mesh;
    Color taggedColor = Color.blue;

    public bool IsTagged { get { return isTagged; } set { isTagged = value; } }
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        taggedColor = colors[Random.Range(0, colors.Count)];
    }
    private void ChangeColor(Ball target)
    {
        target.isTagged = true;
        target.mesh.material.color = target.taggedColor;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            Ball otherBall = collision.gameObject.GetComponent<Ball>();
            if (isTagged)
            {
                ChangeColor(otherBall);
            }
            else if (otherBall.IsTagged)
            {
                ChangeColor(this);
            }
        }
    }
}
