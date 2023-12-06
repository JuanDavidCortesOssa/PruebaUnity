using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventorySlotsManager : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> emptyInventorySlots;
    [SerializeField] private List<ObjectSlot> emptyObjectSlots;

    public Transform GetEmptySlotTransform()
    {
        if (emptyInventorySlots.Count < 1) return null;

        var transform = emptyInventorySlots[0].transform;
        emptyInventorySlots.RemoveAt(0);

        return transform;
    }

    public Transform GetObjectSlotByType(ObjectType objectType)
    {
        for (var i = 0; i < emptyObjectSlots.Count; i++)
        {
            if (emptyObjectSlots[i].objectType == objectType)
            {
                var transform = emptyObjectSlots[i].transform;
                emptyObjectSlots.RemoveAt(i);

                return transform;
            }
        }

        return null;
    }
}