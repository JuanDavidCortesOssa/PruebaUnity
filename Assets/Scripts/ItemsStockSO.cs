using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsStockSO", menuName = "SO/Items Stock")]
public class ItemsStockSO : ScriptableObject
{
    public List<InventoryObjectData> inventoryObjects;
}