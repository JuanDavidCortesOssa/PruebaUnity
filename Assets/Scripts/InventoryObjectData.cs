using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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