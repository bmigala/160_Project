/**************************************************************************
//File Name :       CoinRandomizer.cs
//Author :          Brandon Migala
//Creation Date :   March 31, 2025
//
//Brief Description : This document randomizes the amount of coins in play.
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRandomizer : MonoBehaviour
{
    private int RNG;

    /// <summary>
    /// Applies a 50% chance whether some or all coins will appear throughout the level.
    /// </summary>
    void Start()
    {
        RNG = Random.Range(0, 2);
        if (RNG == 0)
        {
            Destroy(gameObject);
        }
    }
}
