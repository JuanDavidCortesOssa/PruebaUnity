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
    [SerializeField] private ItemsStockSO itemsStockSo;

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
        InitializeDraggableObjects();
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
        InitializePlayerObjects();
    }

    private void InitializePlayerObjects()
    {
        foreach (var dataId in storedData.objects)
        {
            for (var i = 0; i < itemsStockSo.inventoryObjects.Count; i++)
            {
                if (dataId == i)
                {
                    playerManager.AddToPlayerSlot(itemsStockSo.inventoryObjects[i].objectType,
                        itemsStockSo.inventoryObjects[i].sprite);
                }
            }
        }
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
            var objectData = itemsStockSo.inventoryObjects[itemId];
            var parentTransform = inventorySlotsManager.GetObjectSlotByType(objectData.objectType);
            InstantiateDraggableObject(objectData, parentTransform, itemId);
        }
    }

    private void InstantiateDraggableObjectOnInventory(int itemId)
    {
        var objectData = itemsStockSo.inventoryObjects[itemId];
        var parentTransform = inventorySlotsManager.GetEmptySlotTransform();
        InstantiateDraggableObject(objectData, parentTransform, itemId);
    }

    private void InstantiateDraggableObject(InventoryObjectData objectData, Transform parentTransform, int objectId)
    {
        GameObject instance = Instantiate(draggableObjectGo, parentTransform);
        DraggableObject draggableObject = instance.GetComponent<DraggableObject>();

        draggableObject.Setup(objectData, parentTransform, objectId);
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