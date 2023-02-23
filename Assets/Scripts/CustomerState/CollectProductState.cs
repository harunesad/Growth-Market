using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CollectProductState : CustomerBaseState
{
    public override void EnterState(CustomerStateManager customer)
    {
        //Vector3 scale = new Vector3(JsonSave.json.product[customer.id].transform.localScale.x, JsonSave.json.product[customer.id].transform.localScale.y, JsonSave.json.product[customer.id].transform.localScale.z);
        JsonSave.json.product[customer.id].transform.DOMove(customer.gameObject.transform.position + Vector3.up * 2, 1).SetEase(Ease.Linear).OnComplete(
            () =>
            {
                customer.money -= Data.data.products.products[customer.id].money;
                customer.collectedMoney += Data.data.products.products[customer.id].money;
                //Lists.lists.sections.RemoveAt(customer.id);
                MarketUI.marketUI.MoneyUpdate(customer.collectedMoney);
                GameObject.Destroy(JsonSave.json.product[customer.id]);

                Color myColor = Lists.lists.productsImage[customer.id].GetComponent<Image>().color;
                Color newColor = new Color(myColor.r, myColor.g, myColor.b, 0.5f);
                Lists.lists.productsImage[customer.id].GetComponent<Image>().color = newColor;
                //GameObject.Instantiate
                SpawnCollectedProduct.spawnCollected.SpawnProductImage(Lists.lists.productsImage[customer.id].GetComponent<Image>().sprite);

                customer.SwitchState(customer.moveToProductState);

                Debug.Log(customer.money);

                //Transform productsPointPos = customer.productsPoint.transform;
                //float newPosX = productsPointPos.position.x;
                //newPosX--;
                //customer.productsPoint.transform.position = new Vector3(newPosX, productsPointPos.position.y, productsPointPos.position.z);
            });
        JsonSave.json.product[customer.id].transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 1).SetEase(Ease.Linear).OnComplete(
            () => 
            {
                //GameObject.Destroy(JsonSave.json.product[customer.id]);
                //customer.SwitchState(customer.MoveToProductState);
            });
    }

    public override void OntriggerEnter(CustomerStateManager customer, Collider other)
    {
        
    }

    public override void UpdateState(CustomerStateManager customer)
    {
        
    }
}
