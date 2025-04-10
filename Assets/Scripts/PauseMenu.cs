/*******************************************************************************
//File Name :       PauseMenu.cs
//Author :          Brandon Migala
//Creation Date :   March 13, 2025
//
//Brief Description : This document allows the player to access the pause menu.
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Lists the variables to manage both the pause menu screen and the controls menu screen.
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject instructionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        instructionsMenu.SetActive(false);
    }

    // Activates the PauseMenu.
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    // Backs out of the InstructionsMenu and back into the PauseMenu.
    public void BackButton()
    {
        instructionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    // Activates the InstructionsMenu.
    public void Controls()
    {
        instructionsMenu.SetActive(true);
    }

    // Resumes the game.
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
