using UnityEngine;


[System.Serializable]
public struct DoorState
{
    public bool isDestroyed;
}

[System.Serializable]
public class GameData
{
    public Vector3 position;
    public int health;
    public DoorState[] doorStates;
}


//camelCase
//PascalCase
//snake_case

