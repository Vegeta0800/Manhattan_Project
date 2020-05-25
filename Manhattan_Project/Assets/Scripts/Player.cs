using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [HideInInspector] public int[] boughtUnits;
    public int money;
    public int income;
    public Material color;

    public Text moneyText;
    public Text incomeText;

    [SerializeField] private StartUnits[] startUnits;
    [SerializeField] private Game game;

    // Start is called before the first frame update
    void Start()
    {
        boughtUnits = new int[4];
        moneyText.text = money.ToString();
        incomeText.text = income.ToString();

        foreach(StartUnits start in startUnits)
        {
            SpawnUnits(start.amount, start.type, start.factory);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            game.ToggleBuyMenu();
        }
    }

    private void SpawnUnits(int amount, UnitType type, Transform factory)
    {
        Transform spawnpoint = factory.GetChild(0);

        switch (type)
        {
            case UnitType.Soldier:

                for(int i = 0; i < factory.childCount; i++)
                {
                    if(factory.GetChild(i).name == "Soldier_SP")
                    {
                        spawnpoint = factory.GetChild(i);
                        break;
                    }
                }

                GameObject sol = Instantiate(game.units[0].prefab, spawnpoint.position, Quaternion.identity, spawnpoint);
                sol.GetComponent<Renderer>().material = color;
                sol.name = amount.ToString();
                break;

            case UnitType.Tank:

                for (int i = 0; i < factory.childCount; i++)
                {
                    if (factory.GetChild(i).name == "Tank_SP")
                    {
                        spawnpoint = factory.GetChild(i);
                        break;
                    }
                }

                GameObject tan = Instantiate(game.units[1].prefab, spawnpoint.position, Quaternion.identity, spawnpoint);
                tan.GetComponent<Renderer>().material = color;
                tan.name = amount.ToString();
                break;

            case UnitType.Plane:

                for (int i = 0; i < factory.childCount; i++)
                {
                    if (factory.GetChild(i).name == "Plane_SP")
                    {
                        spawnpoint = factory.GetChild(i);
                        break;
                    }
                }

                GameObject pla = Instantiate(game.units[2].prefab, spawnpoint.position, Quaternion.identity, spawnpoint);
                pla.GetComponent<Renderer>().material = color;
                pla.name = amount.ToString();
                break;

            case UnitType.Boat:

                for (int i = 0; i < factory.childCount; i++)
                {
                    if (factory.GetChild(i).name == "Boat_SP")
                    {
                        spawnpoint = factory.GetChild(i);
                        break;
                    }
                }

                GameObject boa = Instantiate(game.units[3].prefab, spawnpoint.position, Quaternion.identity, spawnpoint);
                boa.GetComponent<Renderer>().material = color;
                boa.name = amount.ToString();
                break;
        }
    }
}