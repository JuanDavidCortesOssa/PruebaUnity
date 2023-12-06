using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectCollectionChannel
{
    public static event Action<int> ObjectCollected;

    public static void OnObjectCollected(int obj)
    {
        ObjectCollected?.Invoke(obj);
    }
}