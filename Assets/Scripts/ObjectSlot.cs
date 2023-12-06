using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectSlot : InventorySlot
{
    public ObjectType objectType;

    public override void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount != 0) return;

        var dropped = eventData.pointerDrag;
        var draggableObject = dropped.GetComponent<DraggableObject>();

        if (draggableObject.objectType != objectType) return;

        draggableObject.parentAfterDrag = transform;
    }
}