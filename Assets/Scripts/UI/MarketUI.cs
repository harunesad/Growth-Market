using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarketUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    string moneyKey = "Money";
    float moneyCount;
    void Start()
    {
        moneyCount = PlayerPrefs.GetFloat(moneyKey);
        moneyText.text = "" + moneyCount;
    }
    void Update()
    {
        
    }
}
