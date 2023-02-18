using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickObject : MonoBehaviour, IPointerClickHandler
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
        for (int i = 0; i < products.products.Count; i++)
        {
            if (products.products[i].product.name == gameObject.name && JsonSave.json.save.products[i] == true)
            {
                Color myColor = gameObject.GetComponent<Image>().color;
                Color newColor = new Color(myColor.r, myColor.g, myColor.b, 1);
                gameObject.GetComponent<Image>().color = newColor;
            }
        }
    }
    void Update()
    {
        
    }
    //private void OnMouseDown()
    //{
    //    for (int i = 0; i < products.products.Count; i++)
    //    {
    //        if (products.products[i].product.name == gameObject.name && JsonSave.json.save.products[i] == true)
    //        {
    //            return;
    //        }
    //        if (products.products[i].product.name == gameObject.name && JsonSave.json.save.products[i] == false)
    //        {
    //            productId = i;
    //            Debug.Log(productId);
    //        }
    //    }
    //    MarketUI.marketUI.GameStart();
    //    MarketUI.marketUI.EnergyReduce();
    //}

    public void OnPointerClick(PointerEventData eventData)
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
