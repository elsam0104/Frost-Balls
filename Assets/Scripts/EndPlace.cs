using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndPlace : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    private int score = 0;
    private bool doesEnd = false;
    private void SetScore()
    {
        scoreText.text = $"{score} Servived";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (!doesEnd)
            {
                doesEnd = true;
                StartCoroutine(WaitForEnding());
            }
            other.GetComponent<SphereCollider>().enabled = false;
            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            score++;
            SetScore();
        }
    }
    private IEnumerator WaitForEnding()
    {
        yield return new WaitForSeconds(4f);
        GameManager.Instance.GameClear();
    }
}
