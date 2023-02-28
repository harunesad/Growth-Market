using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOfferState : CustomerBaseState
{
    public override void EnterState(CustomerStateManager customer)
    {
        //customer.generosity = Random.Range(0, 100);
    }

    public override void OntriggerEnter(CustomerStateManager customer, Collider other)
    {
        
    }

    public override void UpdateState(CustomerStateManager customer)
    {
        
    }
}
