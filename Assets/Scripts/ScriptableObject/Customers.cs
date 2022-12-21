using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Customers", menuName = "ScriptableObject/Customers")]
public class Customers : ScriptableObject
{
    public List<ProductsCollect> customers = new List<ProductsCollect>();
}
[System.Serializable]
public class ProductsCollect
{
    public GameObject customers;
    public int productsCount;
}

