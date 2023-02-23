using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomerStateManager : MonoBehaviour
{
    public GameObject rightDoor;
    public GameObject leftDoor;
    //public GameObject counter;
    public GameObject productsPoint;
    //public GameObject firstProductsPoint;
    public Animator animator;
    public int id;
    public float money;
    public float collectedMoney;

    CustomerBaseState currentState;
    public CustomerMoveToDoorState moveToDoorState = new CustomerMoveToDoorState();
    public CustomerMoveToProductState moveToProductState = new CustomerMoveToProductState();
    public CustomerMoveToCounterState moveToCounterState = new CustomerMoveToCounterState();
    public CollectProductState collectProductState = new CollectProductState();
    public CustomerOfferState customerOfferState = new CustomerOfferState();
    void Start()
    {
        rightDoor = GameObject.Find("RightDoor");
        leftDoor = GameObject.Find("LeftDoor");
        //counter = GameObject.Find("Counter");
        productsPoint = GameObject.Find("ProductsPoint");
        //firstProductsPoint = GameObject.Find("FirstProductsPoint");
        animator = GetComponent<Animator>();
        money = Data.data.customers.customers[SpawnCustomers.spawnCustomers.customerId].money;

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
    //public void DoorOpen()
    //{
    //    door.transform.parent.GetComponent<Animator>().SetBool("Open", true);
    //}
    public void Walk()
    {
        //gameObject.GetComponent<Animator>().SetBool("Walk", true);
        //int id = Random.Range(0, Sections.section.sections.Count);
        //Transform tartgetTransform = Sections.section.sections[id].transform;
        //Vector3 targetPos = new Vector3(tartgetTransform.position.x, transform.position.y, tartgetTransform.position.z);
        //gameObject.GetComponent<NavMeshAgent>().SetDestination(targetPos);
        ////transform.DOMove(targetPos, 5).SetEase(Ease.Linear).OnComplete(
        ////    () =>
        ////    {
        ////        animator.SetBool("Walk", false);
        ////    });
    }
}
