using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomerMoveToDoorState : CustomerBaseState
{
    float switchTime;
    public override void EnterState(CustomerStateManager customer)
    {
        switchTime = 0;
        customer.animator.SetBool("Walk", true);
        customer.gameObject.transform.DOMoveX(customer.door.transform.position.x + 1, 2).SetEase(Ease.Linear).OnComplete(
            () => 
            {
                customer.animator.SetBool("Walk", false);
                customer.animator.SetTrigger("Open");
                //customer.animator.SetBool("Walk", true);
                customer.Invoke("DoorOpen", 0.9f);
                //customer.Invoke("Walk", 1.25f);
            });
    }

    public override void OntriggerEnter(CustomerStateManager customer, Collider other)
    {

    }

    public override void UpdateState(CustomerStateManager customer)
    {
        switchTime += Time.deltaTime;
        if (switchTime >= 3.25f)
        {
            customer.SwitchState(customer.moveToProductState);
        }
    }
}
