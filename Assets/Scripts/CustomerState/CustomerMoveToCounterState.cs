using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomerMoveToCounterState : CustomerBaseState
{
    public override void EnterState(CustomerStateManager customer)
    {
        JsonSave.json.product[customer.id].transform.DOMove(customer.productsPoint.transform.position, 2).OnComplete(
            () =>
            {
                customer.SwitchState(customer.moveToProductState);
                Transform productsPointPos = customer.productsPoint.transform;
                //Vector3 newPointPos = new Vector3(customer.productsPoint.transform.position.x,);
                float newPosX = productsPointPos.position.x;
                newPosX--;
                customer.productsPoint.transform.position = new Vector3(newPosX, productsPointPos.position.y, productsPointPos.position.z);
            });
    }

    public override void OntriggerEnter(CustomerStateManager customer, Collider other)
    {
        
    }

    public override void UpdateState(CustomerStateManager customer)
    {
        
    }
}
