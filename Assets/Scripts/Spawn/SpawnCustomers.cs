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
        Instantiate(customers.customers[Random.Range(0, customersLevel)].customers, customerSpawnPoint.transform.position, Quaternion.identity);
    }
    void Update()
    {

    }
}
