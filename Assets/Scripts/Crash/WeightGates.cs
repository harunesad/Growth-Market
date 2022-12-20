using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class WeightGates : MonoBehaviour
{
    public Products products;
    public static WeightGates weight;
    private void Awake()
    {
        weight = this;
    }
    public void AddWeight(TextMeshProUGUI count, TextMeshProUGUI state, GameObject obj)
    {
        Transform parent = obj.transform.parent;

        float myWeight = GameUI.gameUI.myWeight;
        string newCount = count.text;
        float percent = Convert.ToInt32(newCount) / myWeight;
        if (state.text == "+")
        {
            float result = myWeight + (Convert.ToInt32(newCount) * parent.transform.childCount);
            GameUI.gameUI.MyWeightUpdate(result);

            Vector3 scale;
            float scaleX = parent.transform.localScale.x;
            float scaleY = parent.transform.localScale.y;
            float scaleZ = parent.transform.localScale.z;
            scale = new Vector3(scaleX + (scaleX * percent), scaleY + (scaleY * percent), scaleZ + (scaleZ * percent));
            parent.transform.DOScale(scale, 0.5f);
        }
        if (state.text == "-")
        {
            float result = myWeight - (Convert.ToInt32(newCount) * parent.transform.childCount);
            GameUI.gameUI.MyWeightUpdate(result);

            Vector3 scale;
            float scaleX = parent.transform.localScale.x;
            float scaleY = parent.transform.localScale.y;
            float scaleZ = parent.transform.localScale.z;
            scale = new Vector3(scaleX - (scaleX * percent), scaleY - (scaleY * percent), scaleZ - (scaleZ * percent));
            parent.transform.DOScale(scale, 0.5f);
        }
        for (int i = 0; i < parent.childCount; i++)
        {
            if (i % 2 == 0)
            {
                parent.transform.GetChild(i).DOLocalMoveX(i * 0.3f, 0.5f).SetEase(Ease.Linear);
            }
            else
            {
                parent.transform.GetChild(i).DOLocalMoveX((-i - 1) * 0.3f, 0.5f).SetEase(Ease.Linear);
            }
        }
    }
}
