using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOfferState : CustomerBaseState
{
    public override void EnterState(CustomerStateManager customer)
    {
        customer.generosity = Random.Range(0, 100);
    }

    public override void OntriggerEnter(CustomerStateManager customer, Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(CustomerStateManager customer)
    {
        throw new System.NotImplementedException();
    }
}