using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField]
    private GameDataSO gameDataSO;
    [SerializeField]
    private Ball tmpBall;
    public GameDataSO GameDataSO { get { return gameDataSO; } }
    public List<Ball> taggedBalls = new List<Ball>();
    private Ball lowestBall = null;

    public static BallManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        gameDataSO.haveBall = 1;
        foreach (Transform child in transform)
        {
            Ball ball = child.gameObject.GetComponent<Ball>();
            if (tmpBall == ball)
                continue;
            if (ball != null && ball.IsTagged)
            {
                taggedBalls.Add(ball);
                lowestBall = ball;
            }
        }
    }
    private void Update()
    {
        if (taggedBalls.Count == 0) return;
        FindLowest();
    }
    private void FindLowest()
    {
        for (int i = 0; i < taggedBalls.Count; i++)
        {
            if (taggedBalls[i] == null) continue;
            //if (taggedBalls[i].gameObject.transform.position.y <= -2.0f)
            //{
            //    lowestBall = tmpBall;
            //    Destroy(taggedBalls[i].gameObject);
            //}
            if (taggedBalls[i].transform.position.y < lowestBall.transform.position.y)
                lowestBall = taggedBalls[i];
        }
    }
    public void AddTaggedBall(Ball ball)
    {
        if (!ball.IsTagged) return;
        if (ball == tmpBall) return;
        if (taggedBalls.Contains(ball)) return;
        taggedBalls.Add(ball);
        if (lowestBall == null) lowestBall = ball;
    }
    public void RemoveTaggedBall(Ball ball)
    {
        if (taggedBalls.Contains(ball))
        {
            Ball del = taggedBalls[taggedBalls.IndexOf(ball)];
            //taggedBalls.RemoveAt(taggedBalls.IndexOf(ball));
            Destroy(del.gameObject);
        }
        lowestBall = tmpBall;
    }
    public Transform GetTransform()
    {
        if (lowestBall == null) FindLowest();
        return lowestBall.transform;
    }
    private void OnDestroy()
    {
        instance = null;
    }
}
