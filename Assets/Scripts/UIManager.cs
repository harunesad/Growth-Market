using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager uI;
    public Products products;
    public Image loadingBar;
    public TextMeshProUGUI myWeightText, minWeightText, maxWeightText;
    public TextMeshProUGUI myWeightTypeText, minWeightTypeText, maxWeightTypeText;
    public float myWeight;
    string type;
    private void Awake()
    {
        uI = this;
    }
    void Start()
    {
        myWeight = products.products[ClickObject.click.productId].myWeight;
        myWeightText.text = "" + myWeight;
        minWeightText.text = "" + products.products[ClickObject.click.productId].minWeight;
        maxWeightText.text = "" + products.products[ClickObject.click.productId].maxWeight;
        myWeightTypeText.text = "" + products.products[ClickObject.click.productId].type;
        minWeightTypeText.text = "" + products.products[ClickObject.click.productId].type;
        maxWeightTypeText.text = "" + products.products[ClickObject.click.productId].type;
    }
    void Update()
    {
        myWeightText.text = "" + (int)myWeight;
    }
    public void MyWeightUpdate(float addWeight)
    {
        //myWeight = addWeight;
        DOTween.To(x => myWeight = x, myWeight, addWeight, 2);
        //myWeightText.text = "" + myWeight;
        if (addWeight > Convert.ToInt32(minWeightText.text))
        {
            float spacing = Convert.ToInt32(maxWeightText.text) - Convert.ToInt32(minWeightText.text);
            float progress = addWeight - Convert.ToInt32(minWeightText.text);
            float percent = progress / spacing;
            loadingBar.DOFillAmount(percent, 2);
        }
        else
        {
            loadingBar.DOFillAmount(0, 2);
        }
    }
}
