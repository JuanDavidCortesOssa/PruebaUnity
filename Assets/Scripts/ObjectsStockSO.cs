using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ObjectsStockSo", menuName = "SO/Objects Stock")]
public class ObjectsStockSo : ScriptableObject
{
    public List<InventoryObjectData> inventoryObjects;
}