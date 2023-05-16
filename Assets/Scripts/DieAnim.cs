using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DieAnim : MonoBehaviour
{
    [SerializeField]
    private GameObject destroyObj;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
            DestroyAnim();
    }
    public void DestroyAnim()
    {
        destroyObj.transform.transform.DOScale(0, 1).OnComplete(() => { Destroy(destroyObj.gameObject); }).SetEase(Ease.InCubic);
    }
}
