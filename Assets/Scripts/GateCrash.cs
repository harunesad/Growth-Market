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
                    Debug.Log(parent.transform.childCount - i);
                }
            }
            GameUI.gameUI.MyWeightUpdate(myWeight);
            return;
        }
        float addMyWeight = myWeight / parent.transform.childCount;
        for (int i = 0; i < Convert.ToInt32(newCount); i++)
        {
            var newProduct = Instantiate(products.products[ClickObject.click.productId].product, gameObject.transform.position, Quaternion.identity);
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
    void AddWeight(TextMeshProUGUI count, TextMeshProUGUI state)
    {
        Transform parent = gameObject.transform.parent;

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
            float result = myWeight - (Convert.ToInt32(newCount) * parent.transform.childCount);
            GameUI.gameUI.MyWeightUpdate(result);

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
                parent.transform.GetChild(i).DOLocalMoveX(i * 0.3f, 0.5f).SetEase(Ease.Linear);
            }
            else
            {
                parent.transform.GetChild(i).DOLocalMoveX((-i - 1) * 0.3f, 0.5f).SetEase(Ease.Linear);
            }
        }
    }
}
