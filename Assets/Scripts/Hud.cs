using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Hud : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI userNameText;

    public void SetUserText(string text)
    {
        userNameText.text = text;
    }
}