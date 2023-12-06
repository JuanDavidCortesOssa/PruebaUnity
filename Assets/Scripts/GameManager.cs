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
    [SerializeField] private InventorySlotsManager inventorySlotsManager;

    [SerializeField] private GameObject draggableObjectGo;
    [SerializeField] private ItemsStockSO objectsStockSo;

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

    private void InitializeDraggableObjects()
    {
        foreach (var itemId in storedData.inventory)
        {
            InstantiateDraggableObjectOnInventory(itemId);
        }

        foreach (var itemId in storedData.objects)
        {
            var objectData = objectsStockSo.inventoryObjects[itemId];
            var parentTransform = inventorySlotsManager.GetObjectSlotByType(objectData.objectType);
            InstantiateDraggableObject(objectData, parentTransform);
        }
    }

    private void InstantiateDraggableObjectOnInventory(int itemId)
    {
        var objectData = objectsStockSo.inventoryObjects[itemId];
        var parentTransform = inventorySlotsManager.GetEmptySlotTransform();
        InstantiateDraggableObject(objectData, parentTransform);
    }

    private void InstantiateDraggableObject(InventoryObjectData objectData, Transform parentTransform)
    {
        GameObject instance = Instantiate(draggableObjectGo);
        DraggableObject draggableObject = instance.GetComponent<DraggableObject>();

        draggableObject.Setup(objectData, parentTransform);
    }

    #region AddListeners

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
        ObjectCollectionChannel.ObjectCollected += InstantiateDraggableObjectOnInventory;
    }

    private void RemoveListeners()
    {
        ObjectCollectionChannel.ObjectCollected -= InstantiateDraggableObjectOnInventory;
    }

    #endregion
}