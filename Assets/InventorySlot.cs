using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount != 0) return;

        var dropped = eventData.pointerDrag;
        var draggableObject = dropped.GetComponent<DraggableObject>();
        draggableObject.parentAfterDrag = transform;
    }
}