using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

    [SerializeField]
    private GameObject GameOverUI;
    [SerializeField]
    private GameObject GameClearUI;

    private void Awake()
    {
        Instance = this;
    }
    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }
    public void GameClear()
    {
        GameClearUI.SetActive(true);
    }
    private void OnDestroy()
    {
        Instance = null;
    }
}
