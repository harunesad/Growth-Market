using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

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
        TextMeshProUGUI state = canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI count = canvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI type = canvas.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        if (type.text == "")
        {
            Multiply();
        }
        else
        {
            AddWeight(count, state);
        }
    }
    void Multiply()
    {

    }
    void AddWeight(TextMeshProUGUI count, TextMeshProUGUI state)
    {
        GameObject parent = gameObject.transform.parent.gameObject;

        float myWeight = UIManager.uI.myWeight;
        string newCount = count.text;
        float percent = Convert.ToInt32(newCount) / myWeight;
        if (state.text == "+")
        {
            float result = myWeight + Convert.ToInt32(newCount);
            UIManager.uI.MyWeightUpdate(result);

            for (int i = 0; i < parent.transform.childCount; i++)
            {
                Vector3 scale;
                float scaleX = parent.transform.GetChild(i).transform.localScale.x;
                float scaleY = parent.transform.GetChild(i).transform.localScale.y;
                float scaleZ = parent.transform.GetChild(i).transform.localScale.z;
                scale = new Vector3(scaleX + (scaleX * percent), scaleY + (scaleY * percent), scaleZ + (scaleZ * percent));
                parent.transform.GetChild(i).transform.DOScale(scale, 0.5f);
            }
        }
        if (state.text == "-")
        {
            float result = myWeight - Convert.ToInt32(newCount);
            UIManager.uI.MyWeightUpdate(result);

            for (int i = 0; i < parent.transform.childCount; i++)
            {
                Vector3 scale;
                float scaleX = parent.transform.GetChild(i).transform.localScale.x;
                float scaleY = parent.transform.GetChild(i).transform.localScale.y;
                float scaleZ = parent.transform.GetChild(i).transform.localScale.z;
                scale = new Vector3(scaleX - (scaleX * percent), scaleY - (scaleY * percent), scaleZ - (scaleZ * percent));
                parent.transform.GetChild(i).transform.DOScale(scale, 0.5f);
            }
        }
    }
}
