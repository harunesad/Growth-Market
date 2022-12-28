using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomers : MonoBehaviour
{
    public Customers customers;
    public GameObject customerSpawnPoint;
    int customersLevel;
    string customerKey = "Customer";
    void Start()
    {
        if (PlayerPrefs.HasKey(customerKey))
        {
            customersLevel = PlayerPrefs.GetInt(customerKey);
        }
        else
        {
            customersLevel = 2;
        }
        int customerId = Random.Range(0, 1);
        Quaternion rotation = customers.customers[customerId].customers.transform.rotation;
        Instantiate(customers.customers[customerId].customers, customerSpawnPoint.transform.position, rotation);
    }
    void Update()
    {

    }
}
