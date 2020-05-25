using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Unit[] units;
    [SerializeField] private Player[] players;


    [Header("UI")]
    public GameObject buyMenu;
    public Text[] unitAmounts;

    private int currentPlayerIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        buyMenu.SetActive(false);

        foreach (Player p in players)
        {
            p.gameObject.SetActive(false);
        }

        players[currentPlayerIndex].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuyUnit(int ID)
    {
        if (units[ID].cost <= players[currentPlayerIndex].money)
        {
            players[currentPlayerIndex].money -= units[ID].cost;
            players[currentPlayerIndex].boughtUnits[ID]++;
            unitAmounts[ID].text = "x" + players[currentPlayerIndex].boughtUnits[ID];
            players[currentPlayerIndex].moneyText.text = players[currentPlayerIndex].money.ToString();
        }
    }

    public void SellUnit(int ID)
    {
        if (players[currentPlayerIndex].boughtUnits[ID] > 0)
        {
            players[currentPlayerIndex].money += units[ID].cost;
            players[currentPlayerIndex].boughtUnits[ID]--;
            unitAmounts[ID].text = "x" + players[currentPlayerIndex].boughtUnits[ID];
            players[currentPlayerIndex].moneyText.text = players[currentPlayerIndex].money.ToString();
        }
    }

    public Unit GetUnit(UnitType ID)
    {
        int id = (int)ID;

        if (id < units.Length)
            return units[id];

        return new Unit();
    }

    public void ToggleBuyMenu()
    {
        buyMenu.SetActive(!buyMenu.activeSelf);
    }

    public void NextPlayer()
    {
        currentPlayerIndex++;
    }
}
