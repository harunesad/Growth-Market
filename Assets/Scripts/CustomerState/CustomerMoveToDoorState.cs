using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomerMoveToDoorState : CustomerBaseState
{
    public override void EnterState(CustomerStateManager customer)
    {
        customer.rightDoor.GetComponent<Animator>().SetTrigger("Open");
        customer.leftDoor.GetComponent<Animator>().SetTrigger("Open");
        customer.animator.SetBool("Walk", true);
        customer.gameObject.transform.DOMoveX(customer.rightDoor.transform.position.x + 1, 2).SetEase(Ease.Linear).OnComplete(
            () => 
            {
                customer.animator.SetBool("Walk", false);
                customer.SwitchState(customer.moveToProductState);
            });
    }

    public override void OntriggerEnter(CustomerStateManager customer, Collider other)
    {

    }

    public override void UpdateState(CustomerStateManager customer)
    {
        
    }
}
