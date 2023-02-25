using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonSave : MonoBehaviour
{
    public static JsonSave json;
    public List<GameObject> product = new List<GameObject>();
    public SaveObject save;
    private void Awake()
    {
        json = this;
    }
    void Start()
    {
        //for (int i = 0; i < save.products.Count; i++)
        //{
        //    save.products[i] = true;
        //}
        //SaveManager.Save(save);
        save = SaveManager.Load();
        for (int i = 0; i < save.products.Count; i++)
        {
            if (save.products[i] == true)
            {
                var product = Instantiate(Data.data.products.products[i].product, Lists.lists.sections[i].transform.position, Quaternion.identity);
                this.product[i] = product;
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
    public void ExtraProductsSave(int id)
    {
        save.extraProducts[id] = true;
        SaveManager.Save(save);
    }
}
