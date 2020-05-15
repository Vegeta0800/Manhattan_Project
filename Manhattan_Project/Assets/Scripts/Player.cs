using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public enum PlayerPhase
    {
        BUY = 0,
        COMBATMOV = 1,
        FIGHT = 2,
        NONCOMBATMOV = 3,
        SET = 4,
        ENDMOVE = 5
    }

    private int money;
    private int income;

    private List<string> enemyfieldTags;

    private List<Player> allies;
    private List<Transform> fields;

    private List<Transform> units;
    private List<int> boughtUnits;
    private PlayerPhase currentPhase;

    public void Init(int startMoney, int incomeIn, List<Player> alliesIn, List<Transform> fieldsIn, List<string> enemyfieldTagsIn)
    {
        money = startMoney;
        income = incomeIn;
        enemyfieldTags = enemyfieldTagsIn;

        if(alliesIn != null)
            allies = alliesIn;
        if (fieldsIn != null)
            fields = fieldsIn;
    }

    public void BuyPhase()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Bought Soldier for 1");
            boughtUnits.Add(0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Bought Tank for 2");
            boughtUnits.Add(1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Bought Plane for 3");
            boughtUnits.Add(2);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            currentPhase = PlayerPhase.COMBATMOV;
        }
    }

    public void CombatMovPhase()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (enemyfieldTags.Contains(hit.transform.tag))
                {
                    hit.transform.GetComponent<MeshRenderer>().material = Game.selectedMat;
                }
                else
                {
                }
            }
        }
    }

    public PlayerPhase GetPhase()
    {
        return currentPhase;
    }
}
