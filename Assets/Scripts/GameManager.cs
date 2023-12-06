using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Hud hud;
    [SerializeField] private PlayerManager playerManager;

    private void Start()
    {
        InitializeScene();
    }

    private void InitializeScene()
    {
        InitializeHud();
        InitializePlayerData();
    }

    private void InitializeHud()
    {
        hud.SetUserText(DataManager.CurrentUser);
    }

    private void InitializePlayerData()
    {
        var storedData = DataManager.GetCurrentPlayerData();
        playerManager.playerInventory.inventoryIds = storedData.inventory;
        playerManager.playerInventory.selectedObjectIds = storedData.objects;
        playerManager.UpdatePlayerPosition(storedData.position);
    }
}