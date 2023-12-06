using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Hud hud;

    private void Start()
    {
        InitializeScene();
    }

    private void InitializeScene()
    {
        InitializePlayerName();
    }

    private void InitializePlayerName()
    {
        hud.SetUserText(DataManager.CurrentUser);
    }
}