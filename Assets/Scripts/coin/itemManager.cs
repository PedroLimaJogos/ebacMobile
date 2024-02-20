using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class itemManager : MonoBehaviour
{
    public SOint coins;
    public static itemManager Instance;
    public TextMeshProUGUI uiTextCoins;
    //public int coins;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        Reset();
    }

    private void Start()
    {
        Reset();
    }

    // Update is called once per frame
    private void Reset()
    {
        coins.value = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        //uiTextCoins.text = coins.ToString();
        //UIGameManager.UpdateTextCoins(coins.value.ToString());
    }
}
