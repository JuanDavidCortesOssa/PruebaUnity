using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class InventoryChannel
{
    public static event Action<ObjectType, Sprite> ObjectSlotFilled;

    public static void OnObjectSlotFilled(ObjectType objectType, Sprite sprite)
    {
        ObjectSlotFilled?.Invoke(objectType, sprite);
    }
}