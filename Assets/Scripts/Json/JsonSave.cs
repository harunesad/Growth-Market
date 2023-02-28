using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JsonSave : MonoBehaviour
{
    public static JsonSave json;
    public List<GameObject> product = new List<GameObject>();
    public List<GameObject> extraProduct = new List<GameObject>();
    public SaveObject save;
    private void Awake()
    {
        json = this;
    }
    void Start()
    {
        for (int i = 0; i < save.products.Count; i++)
        {
            save.products[i] = true;
        }
        //for (int i = 0; i < save.extraProducts.Count; i++)
        //{
        //    save.extraProducts[i] = false;
        //}
        SaveManager.Save(save);
        save = SaveManager.Load();
        for (int i = 0; i < Data.data.products.products.Count; i++)
        {
            if (save.products[i] == true)
            {
                Color myColor = Lists.lists.productsImage[i].GetComponent<Image>().color;
                Color newColor = new Color(myColor.r, myColor.g, myColor.b, 1);
                Lists.lists.productsImage[i].GetComponent<Image>().color = newColor;
            }
            else if ( save.products[i] == false)
            {
                Color myColor = Lists.lists.productsImage[i].GetComponent<Image>().color;
                Color newColor = new Color(myColor.r, myColor.g, myColor.b, 0.5f);
                Lists.lists.productsImage[i].GetComponent<Image>().color = newColor;
            }
        }
        for (int i = 0; i < Data.data.extraProducts.extraProducts.Count; i++)
        {
            if (save.extraProducts[i] == true)
            {
                Color myColor = Lists.lists.extraProductsImage[i].GetComponent<Image>().color;
                Color newColor = new Color(myColor.r, myColor.g, myColor.b, 1);
                Lists.lists.extraProductsImage[i].GetComponent<Image>().color = newColor;
            }
            else if (save.extraProducts[i] == false)
            {
                Color myColor = Lists.lists.extraProductsImage[i].GetComponent<Image>().color;
                Color newColor = new Color(myColor.r, myColor.g, myColor.b, 0.5f);
                Lists.lists.extraProductsImage[i].GetComponent<Image>().color = newColor;
            }
        }

        for (int i = 0; i < save.products.Count; i++)
        {
            if (save.products[i] == true)
            {
                var product = Instantiate(Data.data.products.products[i].product, Lists.lists.sections[i].transform.position, Quaternion.identity);
                this.product[i] = product;
            }
        }
        for (int i = 0; i < save.extraProducts.Count; i++)
        {
            if (save.extraProducts[i] == true)
            {
                Vector3 pos = MarketUI.marketUI.extraProductsPoint.transform.position;
                var extraProduct = Instantiate(Data.data.extraProducts.extraProducts[i].product, pos, Quaternion.identity);
                this.extraProduct[i] = extraProduct;
                MarketUI.marketUI.extraProductsPoint.transform.position = new Vector3(pos.x + 0.25f, pos.y, pos.z);
            }
        }
        if (!save.products.Contains(false))
        {
            FindObjectOfType<SpawnCustomers>().enabled = true;
        }
        //for (int i = 0; i < save.products.Count; i++)
        //{
        //    if (save.products[i] == false)
        //    {
        //        return;
        //    }
        //}
        //FindObjectOfType<SpawnCustomers>().enabled = true;
    }
    void Update()
    {
        
    }
    public void ExtraProductsSave(int id)
    {
        save.extraProducts[id] = true;
        SaveManager.Save(save);
    }
}
