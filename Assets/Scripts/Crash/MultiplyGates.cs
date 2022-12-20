using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MultiplyGates : MonoBehaviour
{
    public Products products;
    public static MultiplyGates multiply;
    private void Awake()
    {
        multiply = this;
    }
    public void Multiply(TextMeshProUGUI count, TextMeshProUGUI state, GameObject obj)
    {
        string newCount = count.text;
        Transform parent = obj.transform.parent;
        float myWeight = GameUI.gameUI.myWeight;

        if (state.text == "-")
        {
            float removeMyWeight = myWeight / parent.transform.childCount;
            for (int i = 0; i < Convert.ToInt32(newCount); i++)
            {
                if (parent.transform.childCount - i > 0)
                {
                    Destroy(parent.transform.GetChild(parent.transform.childCount - 1 - i).gameObject);
                    myWeight -= removeMyWeight;
                }
            }
            GameUI.gameUI.MyWeightUpdate(myWeight);
            return;
        }
        float addMyWeight = myWeight / parent.transform.childCount;
        for (int i = 0; i < Convert.ToInt32(newCount); i++)
        {
            var newProduct = Instantiate(products.products[ClickObject.click.productId].product, obj.transform.position, Quaternion.identity);
            newProduct.transform.parent = parent;
            Vector3 scale = new Vector3(1, 1, 1);
            newProduct.transform.localScale = obj.transform.localScale;
        }

        float addWeight = addMyWeight * parent.transform.childCount;
        GameUI.gameUI.MyWeightUpdate(addWeight);

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
