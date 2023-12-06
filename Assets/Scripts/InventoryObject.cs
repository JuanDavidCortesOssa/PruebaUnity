using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryObject : MonoBehaviour, IInteractable
{
    [SerializeField] private int objectId;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Interact();
        }
    }

    public void Interact()
    {
        PickUpObject();
    }
    
    private void PickUpObject()
    {
        //Add to player inventory
        gameObject.SetActive(false);
    }
}
