using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MarketUI : MonoBehaviour
{
    public static MarketUI marketUI;
    public TextMeshProUGUI moneyText, energyText;
    string moneyKey = "Money", energyKey = "Energy";
    float moneyCount, energyCount;
    private void Awake()
    {
        marketUI = this;
    }
    void Start()
    {
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
            StartCoroutine(SceneLoad());
        }
    }
    void Update()
    {
        
    }
    IEnumerator SceneLoad()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
