using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Hud hud;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private List<CollectableObject> collectableObjects;

    private PlayerData.InGameData storedData = new PlayerData.InGameData();

    private void Start()
    {
        InitializeScene();
    }

    private void InitializeScene()
    {
        storedData = DataManager.GetCurrentPlayerData();
        InitializeHud();
        InitializePlayerData();
        InitializeCollectableObjects();
    }

    private void InitializeHud()
    {
        hud.SetUserText(DataManager.CurrentUser);
    }

    private void InitializePlayerData()
    {
        playerManager.playerInventory.inventoryIds = storedData.inventory;
        playerManager.playerInventory.selectedObjectIds = storedData.objects;
        playerManager.UpdatePlayerPosition(storedData.position);
    }

    private void InitializeCollectableObjects()
    {
        foreach (var objectId in storedData.inventory)
        {
            collectableObjects.Where(t => t.objectId == objectId).ToList().ForEach(t => t.gameObject.SetActive(false));
        }

        foreach (var objectId in storedData.objects)
        {
            collectableObjects.Where(t => t.objectId == objectId).ToList().ForEach(t => t.gameObject.SetActive(false));
        }
    }
}