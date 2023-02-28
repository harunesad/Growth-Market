using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMoveToProductState : CustomerBaseState
{
    Vector3 targetPos;
    public override void EnterState(CustomerStateManager customer)
    {
        if (!JsonSave.json.save.products.Contains(true))
        {
            customer.SwitchState(customer.moveToCounterState);
            return;
        }
        customer.id = Random.Range(0, Lists.lists.sections.Count);
        Debug.Log(customer.id);
        if (JsonSave.json.save.products[customer.id] == false)
        {
            customer.SwitchState(customer.moveToProductState);
            return;
        }
        if (customer.money < Data.data.products.products[customer.id].money)
        {
            customer.SwitchState(customer.moveToCounterState);
            Debug.Log(customer.money);
            return;
        }

        customer.GetComponent<Animator>().SetBool("Walk", true);
        Transform tartgetTransform = Lists.lists.sections[customer.id].transform;
        targetPos = new Vector3(tartgetTransform.position.x, customer.transform.position.y, tartgetTransform.position.z);
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
            JsonSave.json.save.products[customer.id] = false;
            SaveManager.Save(JsonSave.json.save);
            customer.SwitchState(customer.collectProductState);
        }
    }
}
