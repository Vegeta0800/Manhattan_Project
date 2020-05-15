using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player[] players;
    [SerializeField] private Transform gameField;

    public static Material selectedMat;

    // Start is called before the first frame update
    void Start()
    {
        players[0] = new Player();
        players[1] = new Player();

        players[0].Init(10, 5, null, GetAllChildren(GetChildByTag(gameField, "P1_Fields")), new List<string>() { "P2_Fields" });
        players[1].Init(10, 5, null, GetAllChildren(GetChildByTag(gameField, "P2_Fields")), new List<string>() { "P1_Fields" });
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Player player in players)
        {
            //BUYPHASE
            while(player.GetPhase() == Player.PlayerPhase.BUY)
            {
                player.BuyPhase();
            }
            //COMBAT MOVEMENT
            while (player.GetPhase() == Player.PlayerPhase.COMBATMOV)
            {
                player.CombatMovPhase();
            }
            //COMBAT
            //NON COMBAT MOVEMENT
            //SET TROOPS
        }
    }
    
    Transform GetChildByTag(Transform t, string tag)
    {
        if (t.childCount == 0) return null;

        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).tag == tag)
                return t.GetChild(i);
        }

        return null;
    }
    List<Transform> GetAllChildren(Transform t)
    {
        if (t.childCount == 0) return null;

        List<Transform> children = new List<Transform>();

        for(int i = 0; i < t.childCount; i++)
        {
            children.Add(t.GetChild(i));
        }

        return children;
    }
}
