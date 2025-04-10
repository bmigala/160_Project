/**************************************************************************
//File Name :       RestartButton.cs
//Author :          Brandon Migala
//Creation Date :   March 31, 2025
//
//Brief Description : This document allows the player to restart the game.
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    // Lists the variables to manage the restart button.
    [SerializeField] private Button restartButton;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        restartButton.onClick.AddListener(Reset);
    }

    /// <summary>
    /// Restarts the game back to the Main Menu.
    /// </summary>
    private void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
