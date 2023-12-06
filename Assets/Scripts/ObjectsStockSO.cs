using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectsStock", menuName = "SO/Objects Stock")]
public class ObjectsStockSo : ScriptableObject
{
    public Dictionary<int, InventoryObject> InventoryObjects;
}