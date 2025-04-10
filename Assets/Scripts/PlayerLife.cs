/***************************************************************
//File Name :       PlayerLife.cs
//Author :          Brandon Migala
//Creation Date :   March 4, 2025
//
//Brief Description : This document manages the player's life.
***************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    // Lists the variables for player regeneration.
    private bool isDead = false;
    [SerializeField] private float reloadDelay = 1.5f;
    public static int Life = 1;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] public GameObject[] LifeIcons;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        UpdateHealthDisplay();
    }

    /// <summary>
    /// Kills the player within contact.
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //makes the player disappear
            GetComponent<Renderer>().enabled = false;

            //stops the player movement
            GetComponent<PlayerController>().enabled = false;

            //turns off physics (gravity) for the player
            GetComponent<Rigidbody>().isKinematic = false;

            //turns off player input
            GetComponent<PlayerInput>().enabled = false;

            //DIE
            Die();
        }

        if (collision.gameObject.tag == "DeathPit")
        {
            //makes the player disappear
            GetComponent<Renderer>().enabled = false;

            //stops the player movement
            GetComponent<PlayerController>().enabled = false;

            //turns off physics (gravity) for the player
            GetComponent<Rigidbody>().isKinematic = false;

            //turns off player input
            GetComponent<PlayerInput>().enabled = false;

            //DIE
            Die();
        }
    }

    /// <summary>
    /// Depletes one heart from the lives bar upon death.
    /// </summary>
    private void Die()
    {
        Life--;
        isDead = true;
        if (Life <= 0)
            loseScreen.SetActive(true);
        else
            Invoke("ReloadScene", reloadDelay);
        UpdateHealthDisplay();

        if (Life <= 0)
            Life = 1;
    }

    /// <summary>
    /// Changes the amount of hearts in the lives display.
    /// </summary>
    public void UpdateHealthDisplay()
    {
        for (int i = 0; i < LifeIcons.Length; i++)
        { 
            if (i < Life)
            {
                LifeIcons[i].SetActive(true);
            }
            else
            {
                LifeIcons[i].SetActive(false);
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(LifeIcons[0].GetComponent<RectTransform>());
        }
    }

    /// <summary>
    /// Regenerates the player.
    /// </summary>
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
