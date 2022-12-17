using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProduct : MonoBehaviour
{
    public static SpawnProduct spawnProduct;
    public Products products;
    public GameObject productsParent;
    int productId;
    private void Awake()
    {
        spawnProduct = this;
    }
    public void ProductId(int productId)
    {
        this.productId = productId;
    }
    void Start()
    {
        productId = ClickObject.click.productId;
        Debug.Log(productId);
        var product = Instantiate(products.products[productId].product, 
            new Vector3(0, 0.5f, -90), Quaternion.identity);
        product.transform.parent = productsParent.transform;
        productsParent.transform.position = new Vector3(1, productsParent.transform.position.y, productsParent.transform.position.z);
        product.AddComponent<MeshCollider>();
        product.AddComponent<Rigidbody>();
        product.GetComponent<Rigidbody>().isKinematic = true;
        product.AddComponent<GateCrash>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
