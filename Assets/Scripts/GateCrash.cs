using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateCrash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject canvas = other.transform.GetChild(0).gameObject;
        TextMeshProUGUI count = canvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI type = canvas.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        if (type.text == "")
        {
            Multiply();
        }
        else
        {
            IncreaseOrReduce(count, type);
        }
    }
    void Multiply()
    {

    }
    void IncreaseOrReduce(TextMeshProUGUI count, TextMeshProUGUI type)
    {
        float myWeight = SpawnProduct.spawnProduct.products.products[ClickObject.click.productId].myWeight;
        float percent = Convert.ToInt32(count) / myWeight;
        float value = myWeight * percent;
        if (type.text == "+")
        {
            float result = myWeight + value;
        }
        if (type.text == "-")
        {
            float result = myWeight - value;
        }
    }
}
