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
    [SerializeField]
    GameDataSO gameData;
    MeshRenderer mesh;
    Color taggedColor = Color.blue;

    public bool IsTagged { get { return isTagged; } set { isTagged = value; } }
    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        taggedColor = colors[Random.Range(0, colors.Count)];
        if (isTagged)
            ChangeColor(this);
    }
    private void ChangeColor(Ball target)
    {
        target.isTagged = true;
        target.mesh.material.color = target.taggedColor;
        BallManager.instance.AddTaggedBall(target);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            Ball otherBall = collision.gameObject.GetComponent<Ball>();
            if (isTagged && !otherBall.isTagged)
            {
                ChangeColor(otherBall);
                gameData.haveBall++;
            }
        }
    }
}
