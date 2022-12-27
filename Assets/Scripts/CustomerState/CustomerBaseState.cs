using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomerBaseState
{
    public abstract void EnterState(CustomerStateManager customerStateManager);
    public abstract void UpdateState(CustomerStateManager customerStateManager);
    public abstract void OntriggerEnter(CustomerStateManager customerStateManager, Collider other);
}
