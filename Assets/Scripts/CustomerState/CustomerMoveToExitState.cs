using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomerMoveToExitState : CustomerBaseState
{
    public override void EnterState(CustomerStateManager customer)
    {
        if (customer.collectedMoney != 0)
        {
            for (int i = 0; i < Lists.lists.collectProductsImage.Count; i++)
            {
                GameObject.Destroy(Lists.lists.collectProductsImage[i].gameObject);
                Lists.lists.collectProductsImage.RemoveAt(i);
                i--;
            }
        }
        
        MarketUI.marketUI.moneyCount += customer.collectedMoney;
        PlayerPrefs.SetFloat("Money", MarketUI.marketUI.moneyCount);
        MarketUI.marketUI.moneyText.text = "" + PlayerPrefs.GetFloat("Money");
        customer.rightDoor.GetComponent<Animator>().SetTrigger("Open");
        customer.leftDoor.GetComponent<Animator>().SetTrigger("Open");
        customer.animator.SetBool("Walk", true);
        customer.gameObject.transform.DOMoveX(customer.rightDoor.transform.position.x, 2).SetEase(Ease.Linear).OnComplete(
            () =>
            {
                Vector3 targetPos = new Vector3(customer.rightDoor.transform.position.x, customer.transform.position.y, customer.rightDoor.transform.position.z);
                //customer.transform.LookAt(targetPos);
                customer.gameObject.transform.DOMoveX(customer.rightDoor.transform.position.x + 5, 2).SetEase(Ease.Linear).OnComplete(
                    () =>
                    {
                        customer.collectedMoney = 0;
                        MarketUI.marketUI.collectedMoneyText.text = "" + customer.collectedMoney;
                        GameObject.Destroy(customer.gameObject);
                        customer.hatch.GetComponent<RectTransform>().DOScaleX(1, 1).SetEase(Ease.Linear);
                        if (JsonSave.json.save.products.Contains(true))
                        {
                            SpawnCustomers.spawnCustomers.SpawnCustomer();
                        }
                    });
            });
    }

    public override void OntriggerEnter(CustomerStateManager customer, Collider other)
    {
        
    }

    public override void UpdateState(CustomerStateManager customer)
    {
        Vector3 targetPos = new Vector3(customer.rightDoor.transform.position.x + 7, customer.transform.position.y, customer.rightDoor.transform.position.z);
        customer.transform.LookAt(targetPos);
        //customer.transform.LookAt(customer.rightDoor.transform);
    }
}
