using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPlayerPosition : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject player;

    private void Update()
    {
        text.text = SetVectorAsText(player.transform.position);
    }

    private string SetVectorAsText(Vector3 vector3)
    {
        var formattedText = $"( {vector3.x:F1} , {vector3.y:F1} )";
        return formattedText;
    }
}