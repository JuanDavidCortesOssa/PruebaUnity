using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image Image;
    public ObjectType objectType;
    [HideInInspector] public Transform parentAfterDrag;
    public int objectId;

    public void Setup(InventoryObjectData objectData, Transform parentTransform, int objId)
    {
        Image.sprite = objectData.sprite;
        objectType = objectData.objectType;
        parentAfterDrag = parentTransform;
        objectId = objId;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var transform1 = transform;

        parentAfterDrag = transform1.parent;
        transform.SetParent(transform1.root);
        transform.SetAsLastSibling();
        Image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        Image.raycastTarget = true;
    }
}