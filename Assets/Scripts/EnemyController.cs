/********************************************************
//File Name :       EnemyController.cs
//Author :          Brandon Migala
//Creation Date :   March 6, 2025
//
//Brief Description : This document controls the enemies.
********************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// Detects if a sickle has hit an enemy before it's deafeated.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Destroy(other.transform.gameObject);
            Destroy(gameObject);
        }
    }
}
