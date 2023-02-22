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
        Vector3 pos = collectedProductImage.GetComponent<RectTransform>().localPosition;
        var collectedProduct = Instantiate(collectedProductImage);
        collectedProduct.transform.parent = productsPanel.transform;
        collectedProduct.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        collectedProduct.GetComponent<RectTransform>().localPosition = pos;
        collectedProduct.GetComponent<Image>().sprite = productSprite;
    }
}
