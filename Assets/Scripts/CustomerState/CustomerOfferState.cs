using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CustomerOfferState : CustomerBaseState
{
    public override void EnterState(CustomerStateManager customer)
    {
        SpawnCollectedProduct.spawnCollected.SpawnProductImage(Lists.lists.extraProductsImage[MarketUI.marketUI.id].GetComponent<Image>().sprite);
        customer.collectedMoney += Data.data.extraProducts.extraProducts[MarketUI.marketUI.id].money;
        MarketUI.marketUI.collectedMoneyText.text = "" + customer.collectedMoney;
        JsonSave.json.extraProduct[MarketUI.marketUI.id].transform.DOMove(customer.gameObject.transform.position + Vector3.up * 2, 2).SetEase(Ease.Linear);
        JsonSave.json.extraProduct[MarketUI.marketUI.id].transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 2).SetEase(Ease.Linear).OnComplete(
        () =>
        {
            JsonSave.json.save.extraProducts[MarketUI.marketUI.id] = false;
            Vector3 pos = MarketUI.marketUI.extraProductsPoint.transform.position;
            MarketUI.marketUI.extraProductsPoint.transform.position = new Vector3(pos.x - 0.25f, pos.y, pos.z);
            Lists.lists.extraProductsImage[MarketUI.marketUI.id].color = new Color(1, 1, 1, 0.5f);
            customer.SwitchState(customer.moveToExitState);
        });

    }

    public override void OntriggerEnter(CustomerStateManager customer, Collider other)
    {

    }

    public override void UpdateState(CustomerStateManager customer)
    {

    }
}
