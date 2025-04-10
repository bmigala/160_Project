/*******************************************************************************
//File Name :       FollowPlayer.cs
//Author :          Brandon Migala
//Creation Date :   March 4, 2025
//
//Brief Description : This document allows the Main Camera to follow the player.
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Lists the variables to control the camera.
    [SerializeField] private GameObject player;
    private float startingOffset;

    /// <summary>
    /// Happens a fraction of a second after Update & FixedUpdate.
    /// </summary>
    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z +
            startingOffset);
    }

    /// <summary>
    /// Sets the starting camera with current player position.
    /// </summary>
    private void Start()
    {
        startingOffset = transform.position.z;
    }
}
