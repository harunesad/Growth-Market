using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerStateManager : MonoBehaviour
{
    CustomerBaseState currentState;
    public CustomerMoveToDoorState moveToDoorState = new CustomerMoveToDoorState();
    public CustomerMoveToProductState moveToProductState = new CustomerMoveToProductState();
    public CustomerMoveToExitState moveToExitState = new CustomerMoveToExitState();
    void Start()
    {
        currentState = moveToDoorState;
        currentState.EnterState(this);
    }
    private void OnTriggerEnter(Collider other)
    {
       currentState.OntriggerEnter(this, other);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(CustomerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
