using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ObjectsStock", menuName = "SO/Objects Stock")]
public class ObjectsStockSo : ScriptableObject
{
    public List<InventoryObjectData> inventoryObjects;
}

[Serializable]
public enum ObjectType
{
    Head,
    Hands,
    Foots
}

[Serializable]
public class InventoryObjectData
{
    public Sprite sprite;
    public ObjectType objectType;
}