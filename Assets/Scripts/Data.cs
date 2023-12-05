using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Data
{
    public Dictionary<string, PlayerData> PlayersData = new Dictionary<string, PlayerData>();
}

[Serializable]
public class SerializableData
{
    public List<string> playersDataKeys = new List<string>();
    public List<PlayerData> playersDataList = new List<PlayerData>();
}

[Serializable]
public class PlayerData
{
    public string password;
    public InGameData inGameData = new InGameData();

    [Serializable]
    public class InGameData
    {
        public List<Vector2> positions = new List<Vector2>();
        public List<int> inventory = new List<int>();
        public List<int> objects = new List<int>();
    }
}

public static class DataConverter
{
    public static SerializableData ToSerializableData(Data data)
    {
        return new SerializableData
        {
            playersDataKeys = data.PlayersData.Keys.ToList(),
            playersDataList = data.PlayersData.Values.ToList()
        };
    }

    public static Data ToData(SerializableData serializableData)
    {
        var data = new Data();
        for (var i = 0; i < serializableData.playersDataKeys.Count; i++)
        {
            data.PlayersData.Add(serializableData.playersDataKeys[i], serializableData.playersDataList[i]);
        }

        return data;
    }
}