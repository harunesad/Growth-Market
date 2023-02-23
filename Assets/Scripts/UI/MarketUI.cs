using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class MarketUI : MonoBehaviour
{
    public static MarketUI marketUI;
    public TextMeshProUGUI moneyText, energyText, collectedMoneyText, customerMoneyText, customerGenerosityText;
    public GameObject shelves;
    public GameObject customerInfo;
    public GameObject market;
    string moneyKey = "Money", energyKey = "Energy";
    float moneyCount, energyCount;
    int sceneId;
    private void Awake()
    {
        marketUI = this;
    }
    void Start()
    {
        sceneId = SceneManager.GetActiveScene().buildIndex;
        //PlayerPrefs.SetFloat(moneyKey, 0);
        moneyCount = PlayerPrefs.GetFloat(moneyKey);
        moneyText.text = "" + moneyCount;

        if (PlayerPrefs.HasKey(energyKey))
        {
            energyCount = PlayerPrefs.GetFloat(energyKey);
            energyText.text = "" + energyCount;
            return;
        }
        energyCount = 10;
        energyText.text = "" + energyCount;
    }
    public void EnergyReduce()
    {
        if (energyCount > 0)
        {
            energyCount--;
            PlayerPrefs.SetFloat(energyKey, energyCount);
            energyText.text = "" + energyCount;
        }
    }
    public void GameStart()
    {
        if (energyCount > 0)
        {
            sceneId = 2;
            StartCoroutine(SceneLoad());
        }
    }
    void Update()
    {
        
    }
    IEnumerator SceneLoad()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneId);
    }
    public void ShelvesOpen()
    {
        bool shelvesState = shelves.activeSelf;
        shelves.SetActive(!shelvesState);
    }
    public void MarketOpen()
    {
        bool marketState = market.activeSelf;
        market.SetActive(!marketState);
    }
    public void MarketBuy(TextMeshProUGUI money)
    {
        if (moneyCount >= Convert.ToInt32(money.text) && sceneId != Convert.ToInt32(money.name))
        {
            for (int i = 0; i < JsonSave.json.save.products.Count; i++)
            {
                JsonSave.json.save.products[i] = false;
            }
            SaveManager.Save(JsonSave.json.save);

            moneyCount -= Convert.ToInt32(money.text);
            PlayerPrefs.SetFloat(moneyKey, moneyCount);

            sceneId = Convert.ToInt32(money.name);
            StartCoroutine(SceneLoad());
        }
    }
    public void MoneyUpdate(float collectedMoney)
    {
        collectedMoneyText.text = "" + collectedMoney;
    }
    public void CustomerInfoOpen()
    {
        //customerMoneyText.text=""+Data.data.customers.customers[cus]
        SpawnCustomers.spawnCustomers.CustomerInfo(customerMoneyText,customerGenerosityText);
        bool state = customerInfo.activeSelf;
        customerInfo.SetActive(!state);
    }
}
