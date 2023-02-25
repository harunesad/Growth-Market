using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Products", menuName = "ScriptableObject/Products")]
public class Products : ScriptableObject
{
    public List<ProductsSlot> products = new List<ProductsSlot>();
}
[System.Serializable]
public class ProductsSlot
{
    public GameObject product;
    public float myWeight;
    public float gateMultiplier;
    public string type;
    public float minWeight;
    public float maxWeight;
    public float money;
}
