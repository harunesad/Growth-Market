using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonSave : MonoBehaviour
{
    public static JsonSave json;
    public SaveObject save;
    public Products products;
    private void Awake()
    {
        json = this;
    }
    void Start()
    {
        save = SaveManager.Load();
        for (int i = 0; i < save.products.Count; i++)
        {
            if (save.products[i] == true)
            {
                Instantiate(products.products[i].product, Sections.section.sections[i].transform.position, Quaternion.identity);
            }
        }
        for (int i = 0; i < save.products.Count; i++)
        {
            if (save.products[i] == false)
            {
                return;
            }
        }
        FindObjectOfType<SpawnCustomers>().enabled = true;
    }
    void Update()
    {
        
    }
}
