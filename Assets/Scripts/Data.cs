using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data
{
    public Dictionary<string, PlayerData> PlayersData;
}

[Serializable]
public class PlayerData
{
    public string password;
    public InGameData inGameData;

    [Serializable]
    public class InGameData
    {
        public List<Vector2> positions;
        public List<int> inventory;
        public List<int> objects;
    }
}