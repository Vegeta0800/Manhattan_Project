using UnityEngine;

[System.Serializable]
public struct Unit
{
    public string Name;
    public int cost;
    public int attack;
    public int defense;
    public int HP;
    public GameObject prefab;
}

public enum UnitType
{
    Soldier = 0,
    Tank = 1,
    Plane = 2,
    Boat = 3
}

[System.Serializable]
public struct StartUnits
{
    public UnitType type;
    public int amount;
    public Transform factory;
}
