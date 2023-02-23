using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CustomerMoveToCounterState : CustomerBaseState
{
    Vector3 targetPos;
    public override void EnterState(CustomerStateManager customer)
    {
        //Color myColor = Lists.lists.productsImage[customer.id].GetComponent<Image>().color;
        //Color newColor = new Color(myColor.r, myColor.g, myColor.b, 0.5f);
        //Lists.lists.productsImage[customer.id].GetComponent<Image>().color = newColor;

        customer.animator.SetBool("Walk", true);
        targetPos = new Vector3(customer.productsPoint.transform.position.x, customer.transform.position.y, customer.productsPoint.transform.position.z);
        customer.GetComponent<NavMeshAgent>().SetDestination(targetPos);
    }

    public override void OntriggerEnter(CustomerStateManager customer, Collider other)
    {

    }

    public override void UpdateState(CustomerStateManager customer)
    {
        customer.transform.LookAt(targetPos);
        if (customer.transform.position.x == targetPos.x)
        {
            customer.animator.SetBool("Walk", false);
            customer.SwitchState(customer.customerOfferState);
        }
    }
}
