using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnGates : MonoBehaviour
{
    public Products products;
    public List<GameObject> gates = new List<GameObject>();
    public List<float> posX = new List<float>();
    public List<float> posZ = new List<float>();
    string value;
    string type;
    void Start()
    {
        for (int i = 0; i < posZ.Count; i++)
        {
            int randomPosx = Random.Range(0, 2);

            var increase = Instantiate(gates[0], new Vector3(posX[randomPosx], 1, posZ[i]), Quaternion.identity);
            posX.RemoveAt(randomPosx);

            GameObject canvasIncrease = increase.transform.GetChild(0).gameObject;
            TextMeshProUGUI increaseCountText = canvasIncrease.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI increaseTypeText = canvasIncrease.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            Value(Random.Range(0, 2));
            increaseCountText.text = "" + value;
            increaseTypeText.text = "" + type;

            //Debug.Log(multiplier.name);

            var reduce = Instantiate(gates[1], new Vector3(posX[0], 1, posZ[i]), Quaternion.identity);
            posX.RemoveAt(0);

            GameObject canvasReduce = reduce.transform.GetChild(0).gameObject;
            TextMeshProUGUI reduceCountText = canvasReduce.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI reduceTypeText = canvasReduce.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            Value(Random.Range(0, 2));
            reduceCountText.text = "" + value;
            reduceTypeText.text = "" + type;

            posX.Add(-1);
            posX.Add(1);
        }
    }
    void Value(int choose)
    {
        switch (choose)
        {
            case 0:
                value = "" + Random.Range(1, 6) * products.products[ClickObject.click.productId].gateMultiplier;
                type = products.products[ClickObject.click.productId].type;
                break;
            case 1:
                value = "" + Random.Range(1, 3);
                type = "";
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
