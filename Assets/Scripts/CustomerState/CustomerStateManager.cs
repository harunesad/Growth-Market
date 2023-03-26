using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CustomerStateManager : MonoBehaviour
{
    public GameObject rightDoor;
    public GameObject leftDoor;
    public GameObject counterPoint;
    public Image hatch;
    public Animator animator;
    public int id;
    public float money;
    public float collectedMoney;
    public float generosity;

    public CustomerBaseState currentState;
    public CustomerMoveToDoorState moveToDoorState = new CustomerMoveToDoorState();
    public CustomerMoveToProductState moveToProductState = new CustomerMoveToProductState();
    public CustomerMoveToCounterState moveToCounterState = new CustomerMoveToCounterState();
    public CollectProductState collectProductState = new CollectProductState();
    public CustomerOfferState customerOfferState = new CustomerOfferState();
    public CustomerMoveToExitState moveToExitState = new CustomerMoveToExitState();
    public FailExtraProductState failExtraProductState = new FailExtraProductState();
    void Start()
    {
        generosity = Random.Range(0, 100);
        rightDoor = GameObject.Find("RightDoor");
        leftDoor = GameObject.Find("LeftDoor");
        counterPoint = GameObject.Find("CounterPoint");
        hatch = GameObject.Find("Hatch").GetComponent<Image>();
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
