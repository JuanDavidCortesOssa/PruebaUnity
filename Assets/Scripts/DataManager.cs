using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static Data StoredData { get; private set; } = new Data();
    private static SerializableData _serializableData = new SerializableData();
    public static string CurrentUser = "";

    private const string PlayerPrefsDataKey = "PlayersData";

    private static void SaveData()
    {
        _serializableData = DataConverter.ToSerializableData(StoredData);
        var json = JsonUtility.ToJson(_serializableData);
        PlayerPrefs.SetString(PlayerPrefsDataKey, json);
        PlayerPrefs.Save();
        Debug.Log(json);
    }

    public static void LoadData()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsDataKey)) return;

        var json = PlayerPrefs.GetString(PlayerPrefsDataKey);
        _serializableData = JsonUtility.FromJson<SerializableData>(json);
        StoredData = DataConverter.ToData(_serializableData);
        Debug.Log(json);
    }

    public static void SelectCurrentPlayer(string userName)
    {
        CurrentUser = userName;
    }

    public static void AddNewPlayer(string userName, string password)
    {
        SelectCurrentPlayer(userName);
        var playerData = new PlayerData
        {
            password = password
        };
        StoredData.PlayersData.Add(CurrentUser, playerData);

        SaveData();
    }

    public static void UpdatePlayerData(PlayerData.InGameData inGameData)
    {
        StoredData.PlayersData[CurrentUser].inGameData = inGameData;
        SaveData();
    }

    public static PlayerData.InGameData GetCurrentPlayerData()
    {
        return StoredData.PlayersData[CurrentUser].inGameData;
    }
}