using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerInventory playerInventory = new PlayerInventory();

    [SerializeField] private SpriteRenderer headSpriteRenderer;
    [SerializeField] private SpriteRenderer handsSpriteRenderer;
    [SerializeField] private SpriteRenderer footsSpriteRenderer;

    #region PlayerInteractions

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Interactable")) return;
        other.gameObject.GetComponent<IInteractable>().Interact();
    }

    #endregion

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
        ObjectCollectionChannel.ObjectCollected += AddObject;
        InventoryChannel.ObjectSlotFilled += AddToPlayerSlot;
    }

    private void RemoveListeners()
    {
        ObjectCollectionChannel.ObjectCollected -= AddObject;
        InventoryChannel.ObjectSlotFilled -= AddToPlayerSlot;
    }

    #endregion

    private void AddObject(int objectId)
    {
        playerInventory.AddObjectToInventory(objectId);
    }

    public void AddToPlayerSlot(ObjectType objectType, Sprite sprite)
    {
        switch (objectType)
        {
            case ObjectType.Head:
                PrepareRenderer(headSpriteRenderer, sprite);
                break;
            case ObjectType.Hands:
                PrepareRenderer(handsSpriteRenderer, sprite);
                break;
            case ObjectType.Foots:
                PrepareRenderer(footsSpriteRenderer, sprite);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(objectType), objectType, null);
        }
    }

    private void PrepareRenderer(SpriteRenderer spriteRenderer, Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
        spriteRenderer.enabled = true;
    }

    public void RemoveFromPlayerSlot(ObjectType objectType)
    {
        headSpriteRenderer.enabled = objectType switch
        {
            ObjectType.Head => false,
            ObjectType.Hands => false,
            ObjectType.Foots => false,
            _ => throw new ArgumentOutOfRangeException(nameof(objectType), objectType, null)
        };
    }

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