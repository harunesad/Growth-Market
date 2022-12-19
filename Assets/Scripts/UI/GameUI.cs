using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameUI : MonoBehaviour
{
    public static GameUI gameUI;
    public Products products;
    public Image loadingBar;
    public TextMeshProUGUI myWeightText, minWeightText, maxWeightText;
    public TextMeshProUGUI myWeightTypeText, minWeightTypeText, maxWeightTypeText;
    public TextMeshProUGUI moneyText;
    float moneyCount, moneyIncCount;
    string moneyKey = "Money", moneyIncKey = "MoneyInc";
    public float myWeight;
    string type;
    private void Awake()
    {
        gameUI = this;
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

        moneyCount = PlayerPrefs.GetFloat(moneyKey);
        moneyText.text = "" + moneyCount;

        if (PlayerPrefs.HasKey(moneyIncKey))
        {
            moneyIncCount = PlayerPrefs.GetFloat(moneyIncKey);
            return;
        }
        moneyIncCount = 5;
    }
    void Update()
    {
        myWeightText.text = "" + (int)myWeight;
    }
    public void MyWeightUpdate(float addWeight)
    {
        //myWeight = addWeight;
        DOTween.To(x => myWeight = x, myWeight, addWeight, 2).SetEase(Ease.Linear);
        //myWeightText.text = "" + myWeight;
        if (addWeight > Convert.ToInt32(minWeightText.text))
        {
            float spacing = Convert.ToInt32(maxWeightText.text) - Convert.ToInt32(minWeightText.text);
            float progress = addWeight - Convert.ToInt32(minWeightText.text);
            float percent = progress / spacing;
            loadingBar.DOFillAmount(percent, 2).SetEase(Ease.Linear);
        }
        else
        {
            loadingBar.DOFillAmount(0, 2).SetEase(Ease.Linear);
        }
    }
    public void MoneyCollect()
    {
        moneyCount += moneyIncCount;
        PlayerPrefs.SetFloat(moneyKey, moneyCount);
        moneyText.text = "" + moneyCount;
        Debug.Log("sadsass");
    }
}
