using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DieAnim : MonoBehaviour
{
    private void Start()
    {
        DestroyAnim();
    }
    public void DestroyAnim()
    {
        gameObject.transform.DOScale(0, 1).OnComplete(() => { Destroy(gameObject); }).SetEase(Ease.InCubic);
    }
}