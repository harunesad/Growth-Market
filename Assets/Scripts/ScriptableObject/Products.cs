using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Products", menuName = "ScriptableObject/Products")]
public class Products : ScriptableObject
{
    public List<ProdectsSlot> products = new List<ProdectsSlot>();
    //public void AddProduct(string productName, float myWeight, float minWeight, float maxWeight)
    //{
    //    bool hasProduct = false;
    //    for (int i = 0; i < products.Count; i++)
    //    {
    //        if (products[i].productName == productName)
    //        {
    //            hasProduct = true;
    //            break;
    //        }
    //    }
    //    if (!hasProduct)
    //    {
    //        products.Add(new ProdectsSlot(productName, myWeight, minWeight, maxWeight));
    //    }
    //}
}
[System.Serializable]
public class ProdectsSlot
{
    public GameObject product;
    public float myWeight;
    public float gateMultiplier;
    public string type;
    public float minWeight;
    public float maxWeight;

    //public ProdectsSlot(string productName, float myWeight, float minWeight, float maxWeight)
    //{
    //    this.productName = productName;
    //    this.myWeight = myWeight;
    //    this.minWeight = minWeight;
    //    this.maxWeight = maxWeight;
    //}
}
