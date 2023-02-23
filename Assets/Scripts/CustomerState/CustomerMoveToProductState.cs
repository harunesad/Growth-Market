using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMoveToProductState : CustomerBaseState
{
    Vector3 targetPos;
    int collectProduct = Data.data.customers.customers[SpawnCustomers.spawnCustomers.customerId].productsCount;
    //int id;
    //GameObject productsPoint;
    public override void EnterState(CustomerStateManager customer)
    {
        //productsPoint = GameObject.Find("ProductsPoint");
        //if (collectProduct == 0)
        //{
        //    Debug.Log("sadsadsad");
        //    Transform firstTransform = customer.firstProductsPoint.transform;
        //    Vector3 firstPos = new Vector3(firstTransform.position.x + 1, firstTransform.position.y, firstTransform.position.z);
        //    customer.productsPoint.transform.position = firstPos;
        //    customer.SwitchState(customer.moveToExitState);
        //    return;
        //}
        if (!JsonSave.json.save.products.Contains(true))
        {
            customer.SwitchState(customer.moveToCounterState);
            return;
        }
        //for (int i = 0; i < JsonSave.json.save.products.Count; i++)
        //{
        //    if (JsonSave.json.save.products[i] == false)
        //    {

        //    }
        //    else
        //    {
        //        break;
        //    }
        //    customer.SwitchState(customer.moveToCounterState);
        //}
        customer.id = Random.Range(0, Lists.lists.sections.Count);
        Debug.Log(customer.id);
        if (JsonSave.json.save.products[customer.id] == false)
        {
            customer.SwitchState(customer.moveToProductState);
            return;
        }
        else
        {
            JsonSave.json.save.products[customer.id] = false;
            SaveManager.Save(JsonSave.json.save);
        }

        if (customer.money < Data.data.products.products[customer.id].money)
        {
            //Transform firstTransform = customer.firstProductsPoint.transform;
            //Vector3 firstPos = new Vector3(firstTransform.position.x + 1, firstTransform.position.y, firstTransform.position.z);
            //customer.productsPoint.transform.position = firstPos;
            customer.SwitchState(customer.moveToCounterState);
            Debug.Log(customer.money);
            return;
        }
        //else
        //{
        //    customer.id = Random.Range(0, Lists.lists.sections.Count);
        //}

        customer.GetComponent<Animator>().SetBool("Walk", true);
        Transform tartgetTransform = Lists.lists.sections[customer.id].transform;
        targetPos = new Vector3(tartgetTransform.position.x, customer.transform.position.y, tartgetTransform.position.z);
        customer.GetComponent<NavMeshAgent>().SetDestination(targetPos);
        //collectProduct--;
        //money -= Data.data.products.products[customer.id].money;
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
            customer.SwitchState(customer.collectProductState);
        }
    }
}
