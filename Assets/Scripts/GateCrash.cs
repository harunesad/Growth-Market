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
        products = SpawnProduct.spawnProduct.products;
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
            Multiply(count, state);
        }
        else
        {
            AddWeight(count, state);
        }
    }
    void Multiply(TextMeshProUGUI count, TextMeshProUGUI state)
    {
        string newCount = count.text;
        Transform parent = gameObject.transform.parent;
        if (state.text == "-")
        {
            for (int i = 0; i < Convert.ToInt32(newCount); i++)
            {
                //Transform parent = gameObject.transform.parent;
                if (parent.transform.childCount - i > 0)
                {
                    Destroy(parent.transform.GetChild(parent.transform.childCount - 1 - i).gameObject);
                    Debug.Log(parent.transform.childCount - i);
                }
            }
            return;
        }
        for (int i = 0; i < Convert.ToInt32(newCount); i++)
        {
            //Transform parent = gameObject.transform.parent;
            var newProduct = Instantiate(products.products[ClickObject.click.productId].product, gameObject.transform.position, Quaternion.identity);
            //Destroy(newProduct.GetComponent<GateCrash>());
            newProduct.transform.parent = parent;
            Vector3 scale = new Vector3(1, 1, 1);
            newProduct.transform.localScale = gameObject.transform.localScale;
            //if (parent.transform.childCount % 2 == 0)
            //{
            //    newProduct.transform.DOLocalMoveX( parent.childCount, 2);
            //}
            //else
            //{
            //    newProduct.transform.DOLocalMoveX( -parent.childCount + 1, 2);
            //}
        }
        for (int i = 0; i < parent.childCount; i++)
        {
            if (i % 2 == 0)
            {
                parent.transform.GetChild(i).DOLocalMoveX(i * 0.5f, 2);
            }
            else
            {
                parent.transform.GetChild(i).DOLocalMoveX((-i - 1) * 0.5f, 2);
            }
        }
    }
    void AddWeight(TextMeshProUGUI count, TextMeshProUGUI state)
    {
        Transform parent = gameObject.transform.parent;

        float myWeight = UIManager.uI.myWeight;
        string newCount = count.text;
        float percent = Convert.ToInt32(newCount) / myWeight;
        if (state.text == "+")
        {
            float result = myWeight + Convert.ToInt32(newCount);
            UIManager.uI.MyWeightUpdate(result);

            Vector3 scale;
            float scaleX = parent.transform.localScale.x;
            float scaleY = parent.transform.localScale.y;
            float scaleZ = parent.transform.localScale.z;
            scale = new Vector3(scaleX + (scaleX * percent), scaleY + (scaleY * percent), scaleZ + (scaleZ * percent));
            parent.transform.DOScale(scale, 0.5f);


            //for (int i = 0; i < parent.transform.childCount; i++)
            //{
            //    Vector3 scale;
            //    float scaleX = parent.transform.GetChild(i).transform.localScale.x;
            //    float scaleY = parent.transform.GetChild(i).transform.localScale.y;
            //    float scaleZ = parent.transform.GetChild(i).transform.localScale.z;
            //    scale = new Vector3(scaleX + (scaleX * percent), scaleY + (scaleY * percent), scaleZ + (scaleZ * percent));
            //    parent.transform.GetChild(i).transform.DOScale(scale, 0.5f);
            //}
        }
        if (state.text == "-")
        {
            float result = myWeight - Convert.ToInt32(newCount);
            UIManager.uI.MyWeightUpdate(result);

            Vector3 scale;
            float scaleX = parent.transform.localScale.x;
            float scaleY = parent.transform.localScale.y;
            float scaleZ = parent.transform.localScale.z;
            scale = new Vector3(scaleX - (scaleX * percent), scaleY - (scaleY * percent), scaleZ - (scaleZ * percent));
            parent.transform.DOScale(scale, 0.5f);

            //for (int i = 0; i < parent.transform.childCount; i++)
            //{
            //    Vector3 scale;
            //    float scaleX = parent.transform.GetChild(i).transform.localScale.x;
            //    float scaleY = parent.transform.GetChild(i).transform.localScale.y;
            //    float scaleZ = parent.transform.GetChild(i).transform.localScale.z;
            //    scale = new Vector3(scaleX - (scaleX * percent), scaleY - (scaleY * percent), scaleZ - (scaleZ * percent));
            //    parent.transform.GetChild(i).transform.DOScale(scale, 0.5f);
            //}
        }
        for (int i = 0; i < parent.childCount; i++)
        {
            if (i % 2 == 0)
            {
                parent.transform.GetChild(i).DOLocalMoveX(i * 0.5f, 2);
            }
            else
            {
                parent.transform.GetChild(i).DOLocalMoveX((-i - 1) * 0.5f, 2);
            }
        }
    }
}
