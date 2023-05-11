using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField]
    private List<Ball> taggedBalls = new List<Ball>();
    [SerializeField]
    private Ball lowestBall = null;
    public static BallManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        foreach (Transform child in transform)
        {
            Ball ball = child.gameObject.GetComponent<Ball>();
            if (ball != null && ball.IsTagged)
            {
                taggedBalls.Add(ball);
                lowestBall = ball;
            }
        }
    }
    private void Update()
    {
        FindLowest();
    }
    private void FindLowest()
    {
        for (int i = 0; i < taggedBalls.Count; i++)
        {
            if (taggedBalls[i].transform.position.y < lowestBall.transform.position.y)
                lowestBall = taggedBalls[i];
        }
    }
    public void AddTaggedBall(Ball ball)
    {
        if (!ball.IsTagged) return;
        taggedBalls.Add(ball);
        if(lowestBall == null) lowestBall = ball;
    }
    public Transform GetTransform()
    {
        if (lowestBall == null) return null;
        return lowestBall.transform;
    }
}
