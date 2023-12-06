using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<InventoryObject> inventoryObjects = new List<InventoryObject>();
    private List<InventoryObject> selectedObjects = new List<InventoryObject>();

    public void AddObjectToInventory(InventoryObject inventoryObject)
    {
        inventoryObjects.Add(inventoryObject);
    }

    public void SelectObject()
    {
    }
}