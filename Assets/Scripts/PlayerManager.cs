using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerInventory playerInventory = new PlayerInventory();

    #region AddObjectsToInventory

    private void OnEnable()
    {
        AddListeners();
    }

    private void OnDisable()
    {
        RemoveListeners();
    }

    private void AddListeners()
    {
        ObjectCollectionChannel.ObjectCollected += AddObject;
    }

    private void RemoveListeners()
    {
        ObjectCollectionChannel.ObjectCollected -= AddObject;
    }

    private void AddObject(int objectId)
    {
        playerInventory.AddObjectToInventory(objectId);
    }

    #endregion

    [ContextMenu("SavePlayerData")]
    private void SavePlayerData()
    {
        var position = transform.position;
        var gameData = new PlayerData.InGameData
        {
            position = new Vector2(position.x, position.y),
            inventory = playerInventory.inventoryIds,
            objects = playerInventory.selectedObjectIds
        };
        DataManager.UpdatePlayerData(gameData);
    }

    public void UpdatePlayerPosition(Vector2 position)
    {
        transform.position = new Vector3(position.x, position.y, 0);
    }
}