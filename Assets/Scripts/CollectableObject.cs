using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CollectableObject : MonoBehaviour, IInteractable
{
    public int objectId;

    public void Interact()
    {
        PickUp();
    }

    private void PickUp()
    {
        ObjectCollectionChannel.OnObjectCollected(objectId);
        gameObject.SetActive(false);
    }
}