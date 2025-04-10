/**********************************************************************
//File Name :       CoinController.cs
//Author :          Brandon Migala
//Creation Date :   March 2, 2025
//
//Brief Description : This document allows the player to collect coins.
**********************************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Lists the variables used for coin collecting.
    [SerializeField] private TMP_Text scoreText;
    private int score;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    /// <summary>
    /// Updates the score with each coin collected.
    /// </summary>
    private void OnTriggerEnter(Collider coinIHit)
    {
        if (coinIHit.gameObject.CompareTag("Coin"))
        {
            // update score.
            score += 1;
            UpdateScoreText();
            Destroy(coinIHit.gameObject);
        }
    }

    /// <summary>
    /// Changes the score number.
    /// </summary>
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
