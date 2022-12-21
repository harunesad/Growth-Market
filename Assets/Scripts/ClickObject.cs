using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickObject : MonoBehaviour
{
    public static ClickObject click;
    public int productId;
    public Products products;
    private void Awake()
    {
        click = this;
    }
    void Start()
    {

    }
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        for (int i = 0; i < products.products.Count; i++)
        {
            if (products.products[i].product.name == gameObject.name && JsonSave.json.save.products[i] == true)
            {
                return;
            }
            if (products.products[i].product.name == gameObject.name && JsonSave.json.save.products[i] == false)
            {
                productId = i;
                Debug.Log(productId);
            }
        }
        MarketUI.marketUI.GameStart();
        MarketUI.marketUI.EnergyReduce();
    }
}
