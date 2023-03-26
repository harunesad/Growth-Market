using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GateCrash : MonoBehaviour
{
    Products products;
    void Start()
    {
        products = Data.data.products;
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Debug.Log("sadsa");
            Destroy(other.gameObject);
            GameUI.gameUI.MoneyCollect();
            return;
        }
        GameObject canvas = other.transform.GetChild(0).gameObject;
        TextMeshProUGUI state = canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI count = canvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI type = canvas.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        if (type.text == "")
        {
            //Multiply(count, state);
            MultiplyGates.multiply.Multiply(count, state, gameObject);
        }
        else
        {
            //AddWeight(count, state);
            WeightGates.weight.AddWeight(count, state, gameObject);
        }
    }
}
