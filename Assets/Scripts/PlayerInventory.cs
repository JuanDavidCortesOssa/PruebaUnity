using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInventory
{
    public List<int> inventoryIds = new List<int>();
    public List<int> selectedObjectIds = new List<int>();

    public void AddObjectToInventory(int inventoryId)
    {
        inventoryIds.Add(inventoryId);
    }

    public void SelectObject(int selectedObjectId)
    {
        for (var index = 0; index < inventoryIds.Count; index++)
        {
            var id = inventoryIds[index];
            if (id != selectedObjectId) continue;
            selectedObjectIds.Add(id);
            inventoryIds.RemoveAt(index);
        }
    }
}