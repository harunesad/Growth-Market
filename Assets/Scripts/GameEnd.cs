using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameEnd : MonoBehaviour
{
    public Products products;
    public GameObject minObj, maxObj;
    public GameObject target;
    public GameObject productsParent;
    float objSpacing, weightSpacing, newWeightSpacing, newObjSpacing;
    void Start()
    {
        productsParent.transform.parent = target.transform.parent;
        productsParent.transform.DOMove(target.transform.position + (Vector3.up * 0.12f), 2).SetEase(Ease.Linear);
        objSpacing = maxObj.transform.position.y - minObj.transform.position.y;
        weightSpacing = products.products[ClickObject.click.productId].maxWeight - products.products[ClickObject.click.productId].minWeight;
        newWeightSpacing = products.products[ClickObject.click.productId].maxWeight - GameUI.gameUI.myWeight;
        newObjSpacing = newWeightSpacing * objSpacing / weightSpacing;
        Invoke("TargetMove", 2.1f);
        Invoke("CompleteProducts", 3.1f);
    }
    void TargetMove()
    {
        target.transform.parent.DOMoveY(maxObj.transform.position.y - newObjSpacing, 0.5f).SetEase(Ease.Linear);
    }
    void CompleteProducts()
    {
        if (target.transform.parent.position.y > maxObj.transform.position.y)
        {
            return;
        }
        if (target.transform.parent.position.y < minObj.transform.position.y)
        {
            return;
        }
        JsonSave.json.save.products[ClickObject.click.productId] = true;
        SaveManager.Save(JsonSave.json.save);
        Debug.Log("gvgv");
    }
    void Update()
    {
        //weightSpacing objSpacing
        //newWeightSpacing newObjSpacing

        //100 0.25
        //50   x
         
    }
}
