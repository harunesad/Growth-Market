using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomers : MonoBehaviour
{
    public static SpawnCustomers spawnCustomers;
    public Customers customers;
    public GameObject customerSpawnPoint;
    public int customerId;
    int customersLevel;
    string customerKey = "Customer";
    private void Awake()
    {
        spawnCustomers = this;
    }
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
        //customerId = Random.Range(0, customersLevel);
        customerId = Random.Range(0, 1);
        Quaternion rotation = customers.customers[customerId].customers.transform.rotation;
        var customer = Instantiate(customers.customers[customerId].customers, customerSpawnPoint.transform.position, rotation);
        customer.AddComponent<CustomerStateManager>();
    }
    void Update()
    {

    }
}
