using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CollectableObject : MonoBehaviour, IInteractable
{
    public int objectId;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Interact();
        }
    }

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