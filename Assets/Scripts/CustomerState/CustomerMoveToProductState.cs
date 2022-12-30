using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class CustomerMoveToProductState : CustomerBaseState
{
    Vector3 targetPos;
    int collectProduct = SpawnCustomers.spawnCustomers.customers.customers[SpawnCustomers.spawnCustomers.customerId].productsCount;
    //int id;
    //GameObject productsPoint;
    public override void EnterState(CustomerStateManager customer)
    {
        //productsPoint = GameObject.Find("ProductsPoint");
        customer.id = Random.Range(0, Sections.section.sections.Count);
        if (collectProduct == 0)
        {
            Debug.Log("sadsadsad");
            Transform firstTransform = customer.firstProductsPoint.transform;
            Vector3 firstPos = new Vector3(firstTransform.position.x + 1, firstTransform.position.y, firstTransform.position.z);
            customer.productsPoint.transform.position = firstPos;
            customer.SwitchState(customer.moveToExitState);
            return;
        }
        if (JsonSave.json.save.products[customer.id] == false)
        {
            customer.SwitchState(customer.moveToProductState);
            return;
        }
        else
        {
            JsonSave.json.save.products[customer.id] = false;
            //SaveManager.Save(JsonSave.json.save);
        }
        customer.GetComponent<Animator>().SetBool("Walk", true);
        Transform tartgetTransform = Sections.section.sections[customer.id].transform;
        targetPos = new Vector3(tartgetTransform.position.x, customer.transform.position.y, tartgetTransform.position.z);
        customer.GetComponent<NavMeshAgent>().SetDestination(targetPos);
        collectProduct--;
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
            customer.SwitchState(customer.moveToCounterState);
            //Product Move
            //JsonSave.json.product[id].transform.DOMove(productsPoint.transform.position, 2);
            //JsonSave.json.product[id].transform.DOMove(productsPoint.transform.position, 2).OnComplete(
            //    () =>
            //    {
            //        customer.SwitchState(customer.moveToProductState);
            //    });
        }
        //if (JsonSave.json.product[id].transform.position == productsPoint.transform.position)
        //{
        //    Debug.Log("ssad");
        //    customer.SwitchState(customer.moveToProductState);
        //}
    }
}
