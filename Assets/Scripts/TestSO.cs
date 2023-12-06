using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestSO_", menuName = "SO/Objects Test")]
public class TestSO : ScriptableObject
{
    public List<InventoryObjectData> inventoryObjects;
}