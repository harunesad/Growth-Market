using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomerStateManager : MonoBehaviour
{
    public GameObject door;
    public GameObject productsPoint;
    public GameObject firstProductsPoint;
    public Animator animator;
    public int id;

    CustomerBaseState currentState;
    public CustomerMoveToDoorState moveToDoorState = new CustomerMoveToDoorState();
    public CustomerMoveToProductState moveToProductState = new CustomerMoveToProductState();
    public CustomerMoveToExitState moveToExitState = new CustomerMoveToExitState();
    public CustomerMoveToCounterState moveToCounterState = new CustomerMoveToCounterState();
    void Start()
    {
        door = GameObject.Find("Door");
        productsPoint = GameObject.Find("ProductsPoint");
        firstProductsPoint = GameObject.Find("FirstProductsPoint");
        animator = GetComponent<Animator>();

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
    public void DoorOpen()
    {
        door.transform.parent.GetComponent<Animator>().SetBool("Open", true);
    }
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
