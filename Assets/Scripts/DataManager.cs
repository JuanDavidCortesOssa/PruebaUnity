using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static Data StoredData { get; private set; }
    private static string currentUser;

    private const string PlayerPrefsDataKey = "PlayersData";

    public static void SaveData()
    {
        var json = JsonUtility.ToJson(StoredData);
        PlayerPrefs.SetString(PlayerPrefsDataKey, json);
        PlayerPrefs.Save();
        Debug.Log(json);
    }

    public static void LoadData()
    {
        var json = PlayerPrefs.GetString(PlayerPrefsDataKey);
        StoredData = JsonUtility.FromJson<Data>(json);
        Debug.Log(json);
    }

    public static void AddNewPlayer(string userName, string password)
    {
        StoredData ??= new Data();

        currentUser = userName;
        var playerData = new PlayerData
        {
            password = password
        };
        StoredData.PlayersData.Add(currentUser, playerData);
    }

    public static void UpdatePlayerData(PlayerData.InGameData inGameData)
    {
        StoredData.PlayersData[currentUser].inGameData = inGameData;
    }
}