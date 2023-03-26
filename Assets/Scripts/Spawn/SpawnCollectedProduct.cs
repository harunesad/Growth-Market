using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCollectedProduct : MonoBehaviour
{
    public static SpawnCollectedProduct spawnCollected;
    public GameObject collectedProductImage;
    public GameObject productsPanel;
    private void Awake()
    {
        spawnCollected = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void SpawnProductImage(Sprite productSprite)
    {
        RectTransform product = collectedProductImage.GetComponent<RectTransform>();
        Vector3 pos = new Vector3(Random.Range(product.localPosition.x - 150, product.localPosition.x + 150), product.localPosition.y, product.localPosition.z); ;
        var collectedProduct = Instantiate(collectedProductImage);
        collectedProduct.transform.parent = productsPanel.transform;
        collectedProduct.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        collectedProduct.GetComponent<RectTransform>().localPosition = pos;
        collectedProduct.GetComponent<Image>().sprite = productSprite;
        Lists.lists.collectProductsImage.Add(collectedProduct.GetComponent<Image>());
    }
}
