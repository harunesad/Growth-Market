using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MarketUI : MonoBehaviour
{
    public static MarketUI marketUI;
    CustomerStateManager customerState;
    public TextMeshProUGUI moneyText, energyText, collectedMoneyText, customerMoneyText, customerGenerosityText;
    public Image yesOffer, noOffer;
    public GameObject shelves;
    public GameObject extraProductsPoint;
    public GameObject customerInfo;
    public GameObject market;
    public GameObject shop;
    string moneyKey = "Money", energyKey = "Energy";
    public float moneyCount, energyCount;
    public int id;
    int sceneId;
    private void Awake()
    {
        marketUI = this;
    }
    void Start()
    {
        sceneId = SceneManager.GetActiveScene().buildIndex;
        //moneyCount = PlayerPrefs.GetFloat(moneyKey);
        moneyCount = 0;
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
        SpawnCustomers.spawnCustomers.CustomerInfo(customerMoneyText,customerGenerosityText);
        bool state = customerInfo.activeSelf;
        customerInfo.SetActive(!state);
    }
    public void OffferResult()
    {
        yesOffer.gameObject.SetActive(true);
        noOffer.gameObject.SetActive(true);
    }
    public void OfferStart()
    {
        shop.SetActive(true);
    }
    public void NonOffer()
    {
        customerState = FindObjectOfType<CustomerStateManager>();
        customerState.SwitchState(customerState.moveToExitState);
    }
    public void CustomerBuyToExtraProducts(int buttonId)
    {
        customerState = FindObjectOfType<CustomerStateManager>();
        id = buttonId;
        if (customerState.money >= Data.data.extraProducts.extraProducts[id].money && customerState.generosity >= Data.data.customers.customers[SpawnCustomers.spawnCustomers.customerId].generosity && JsonSave.json.save.extraProducts[id] == true)
        {
            customerState.SwitchState(customerState.customerOfferState);
            shop.SetActive(false);
            return;
        }
        /*
        else if (customerState.money >= Data.data.extraProducts.extraProducts[id].money && customerState.generosity < Data.data.customers.customers[SpawnCustomers.spawnCustomers.customerId].generosity)
        {
            customerState.SwitchState(customerState.failExtraProductState);
            shop.SetActive(false);
        }
    */
        customerState.SwitchState(customerState.failExtraProductState);
        shop.SetActive(false);
    }
    public void ExtraProductsBuy(int id)
    {
        if (moneyCount >= Data.data.extraProducts.extraProducts[id].money && JsonSave.json.save.extraProducts[id] == false)
        {
            moneyCount -= Data.data.extraProducts.extraProducts[id].money;
            moneyText.text = "" + moneyCount;
            PlayerPrefs.SetFloat(moneyKey, moneyCount);
            JsonSave.json.ExtraProductsSave(id);
            Lists.lists.extraProductsImage[id].color = new Color(1, 1, 1, 1);

            Vector3 pos = extraProductsPoint.transform.position;
            var extraProduct = Instantiate(Data.data.extraProducts.extraProducts[id].product, pos, Quaternion.identity);
            JsonSave.json.extraProduct[id] = extraProduct;
            extraProductsPoint.transform.position = new Vector3(pos.x + 0.25f, pos.y, pos.z);
        }
    }
}
