using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField userField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private Button button;

    private void Start()
    {
        DataManager.LoadData();
        AddListeners();
    }

    private void AddListeners()
    {
        button.onClick.AddListener(LogUser);
    }

    private void LogUser()
    {
        var userName = userField.text;
        var password = passwordField.text;

        if (DataManager.StoredData.PlayersData.TryGetValue(userName, out var playerData))
        {
            if (playerData.password.Equals(password))
            {
                DataManager.SelectCurrentPlayer(userName);
                Debug.Log("Bienvenido " + userName);
            }
            else
            {
                Debug.Log("Incorrect password");
            }
        }
        else
        {
            DataManager.AddNewPlayer(userName, password);
        }
    }
}