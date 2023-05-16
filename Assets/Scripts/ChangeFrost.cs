using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFrost : MonoBehaviour
{
    public static ChangeFrost Instance;
    private FrostEffect _effect;
    private void Start()
    {
        Instance = this;
        _effect = FindObjectOfType<FrostEffect>();
    }

    public void AddFrost(float changeVal)
    {
        _effect.FrostAmount = Mathf.Clamp01(changeVal+ _effect.FrostAmount);
    }
}
