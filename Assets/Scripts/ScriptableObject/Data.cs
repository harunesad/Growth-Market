using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data data;
    public Products products;
    public Customers customers;
    public ExtraProducts extraProducts;
    private void Awake()
    {
        data = this;
    }
}
