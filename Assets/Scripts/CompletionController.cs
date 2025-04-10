/***************************************************************************************************
//File Name :       CompletionController.cs
//Author :          Brandon Migala
//Creation Date :   March 9, 2025
//
//Brief Description : This document allows the player to complete the level and advance to the next.
***************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletionController : MonoBehaviour
{
    // Lists the variable to operate the WinText.
    [SerializeField] private GameObject WinText;

    /// <summary>
    /// Ends the level when the player triggers the set gameObject.
    /// </summary>
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            // loads the next level
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            WinText.SetActive(true);
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.PlayerMovement = false;
        }
    }
}
