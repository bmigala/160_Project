/***********************************************************************************************
//File Name :       CameraSwitching.cs
//Author :          Brandon Migala
//Creation Date :   March 27, 2025
//
//Brief Description : This document allows the player to change cameras between different rooms.
***********************************************************************************************/
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
    // Lists the asset for operating the cameras.
    [SerializeField] private CinemachineVirtualCamera Cameras;

    /// <summary>
    /// The camera follows the player in the room it's positioned at.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cameras.Priority = 20;
        }
    }

    /// <summary>
    /// Changes cameras when the player has entered a different room.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cameras.Priority = 10;
        }
    }
}
