using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomerBaseState
{
    public abstract void EnterState(CustomerStateManager customer);
    public abstract void UpdateState(CustomerStateManager customer);
    public abstract void OntriggerEnter(CustomerStateManager customer, Collider other);
}
