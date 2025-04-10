/*******************************************************************************
//File Name :       MainMenu.cs
//Author :          Brandon Migala
//Creation Date :   March 27, 2025
//
//Brief Description : This document allows the player to navigate the main menu.
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Lists the variable to manage the main menu screen.
    [SerializeField] private GameObject mainMenu;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        mainMenu.SetActive(true);
    }

    /// <summary>
    /// Starts the game.
    /// </summary>
    public void startButton()
    {
        mainMenu.SetActive(false);
        Time.timeScale = 1f;

        SceneManager.LoadScene(1);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
