using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum CalculateMode
{
    Add,
    Sub,
    Mul,
    Div,
}
public class BonFire : MonoBehaviour
{
    [SerializeField]
    private TMP_Text calculateText;
    [SerializeField]
    private int calculateNum = 2;
    [SerializeField]
    private CalculateMode calculateMode = CalculateMode.Add;
    [SerializeField]
    private GameObject ballPrefab;
    private int completedBallNum = 0;
    private int firstBallNum = 0;
    private List<GameObject> calculatedBalls = new List<GameObject>();
    private void Start()
    {
        SetText();
    }
    private void SetText()
    {
        char sign = '+';
        switch (calculateMode)
        {
            case CalculateMode.Add:
                sign = '+';
                break;
            case CalculateMode.Sub:
                sign = '-';
                break;
            case CalculateMode.Mul:
                sign = 'x';
                break;
            case CalculateMode.Div:
                sign = '¡À';
                break;
            default:
                break;
        }
        calculateText.text = $"{sign} {calculateNum}";
    }
    private void Calculate(Collider collider)
    {
        int ballNum = BallManager.instance.GameDataSO.haveBall;
        switch (calculateMode)
        {
            case CalculateMode.Add:
                {
                    if (completedBallNum >= calculateNum) return;
                    completedBallNum++;
                    GameObject ball = Instantiate(ballPrefab, BallManager.instance.transform);
                    ChangeFrost.Instance.AddFrost(-0.05f);
                    ball.GetComponent<Ball>().AddBallNum();
                    ball.transform.position = new Vector3(transform.position.x, transform.position.y, 0.26f);
                    break;
                }
            case CalculateMode.Mul:

                if (completedBallNum > calculateNum * firstBallNum)
                {
                    calculatedBalls.Clear();
                    return;
                }
                if (calculatedBalls.Contains(collider.gameObject)) return;
                for (int i = 0; i < calculateNum; i++)
                {
                    completedBallNum++;
                    ChangeFrost.Instance.AddFrost(-0.05f);
                    GameObject ball = Instantiate(ballPrefab, BallManager.instance.transform);
                    ball.GetComponent<Ball>().AddBallNum();
                    calculatedBalls.Add(ball);
                    ball.transform.position = new Vector3(transform.position.x, transform.position.y, 0.26f);
                }
                break;
            case CalculateMode.Sub:
                completedBallNum++;
                if (completedBallNum >= calculateNum) return;
                if (completedBallNum != calculateNum)
                {
                    BallManager.instance.RemoveTaggedBall(collider.GetComponent<Ball>());
                }
                break;
            case CalculateMode.Div:
                completedBallNum++;
                if (completedBallNum % calculateNum != 0) return;
                //if (firstBallNum - (firstBallNum / calculateNum) >= completedBallNum)
                //{
                BallManager.instance.RemoveTaggedBall(collider.GetComponent<Ball>());
                //}
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (firstBallNum == 0) { firstBallNum = BallManager.instance.GameDataSO.haveBall; }
        if (other.CompareTag("Ball"))
        {
            if(!other.GetComponent<Ball>().IsTagged) return;
            Calculate(other);
        }
    }
}
