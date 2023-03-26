using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FailExtraProductState : CustomerBaseState
{
    public override void EnterState(CustomerStateManager customer)
    {
        customer.collectedMoney = 0;
        MarketUI.marketUI.collectedMoneyText.text = "" + customer.collectedMoney;
        customer.hatch.GetComponent<RectTransform>().DOScaleX(0.01f, 1).SetEase(Ease.Linear).OnComplete(
            () =>
            {
                customer.SwitchState(customer.moveToExitState);
            });
    }

    public override void UpdateState(CustomerStateManager customer)
    {
        
    }

    public override void OntriggerEnter(CustomerStateManager customer, Collider other)
    {
        
    }
}
