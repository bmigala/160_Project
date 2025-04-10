/*************************************************************
//File Name :       PlayerController.cs
//Author :          Brandon Migala
//Creation Date :   March 2, 2025
//
//Brief Description : This document allows the player to move.
*************************************************************/
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Lists the variables used to control the player.
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float jumpValue = 7f;

    private InputAction move;
    private InputAction restart;
    private InputAction quit;
    private InputAction freeze;
    private Rigidbody rb;
    private Vector3 playerMovement;
    private Vector3 playerScale;
    private Animator animator;
    private PauseMenu pauseMenu;
    [HideInInspector] public bool PlayerMovement = true;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float BoxCastDistance;
    [SerializeField] private LayerMask jumpMask;
    [SerializeField] private GameObject sicklePrefab;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput.currentActionMap.Enable();
        move = playerInput.currentActionMap.FindAction("Move");
        restart = playerInput.currentActionMap.FindAction("Restart");
        quit = playerInput.currentActionMap.FindAction("Quit");
        freeze = playerInput.currentActionMap.FindAction("Freeze");
        pauseMenu = FindAnyObjectByType<PauseMenu>();

        move.started += Move_started;
        move.canceled += Move_canceled;
        restart.performed += Restart_performed;
        quit.performed += Quit_performed;
        freeze.performed += Freeze_performed;
        animator = GetComponent<Animator>();

        StartCoroutine(ApplyMovement());
    }

    /// <summary>
    /// Sets the idle animation when the player is motionless.
    /// </summary>
    private void Move_canceled(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            animator.SetBool("Move", false);
        }
    }

    /// <summary>
    /// Sets the move animation for the player when in motion.
    /// </summary>
    private void Move_started(InputAction.CallbackContext obj)
    {
        //playerScale = new Vector3(move.ReadValue<float>(), 1, 1);
        //gameObject.transform.localScale = playerScale;
    }

    /// <summary>
    /// Restarts the game.
    /// </summary>
    private void Restart_performed(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Closes the program.
    /// </summary>
    private void Quit_performed(InputAction.CallbackContext obj)
    {
        Application.Quit();
    }

    /// <summary>
    /// Freezes time for the player.
    /// </summary>
    private void Freeze_performed(InputAction.CallbackContext obj)
    {
        if (Time.timeScale == 0.25)
        {
            Time.timeScale = 1f;
            playerSpeed /= 2;
            animator.speed = 1;
        }
        else
        {
            Time.timeScale = 0.25f;
            playerSpeed *= 2;
            animator.speed = 4f;
        }
    }    
    /// <summary>
    /// Changes the angle the player is facing within movement.
    /// </summary>
    void OnMove(InputValue iValue)
    {
        if (PlayerMovement == false)
        {
            return;
        }
        Vector2 inputMovement = iValue.Get<Vector2>();
        playerMovement.x = inputMovement.x * playerSpeed;
        playerMovement.z = inputMovement.y * playerSpeed;
        animator.SetBool("Move", true);
        if (inputMovement.x != 0)
        {
            playerScale = new Vector3(inputMovement.x, 1, 1);

            gameObject.transform.localScale = playerScale;
        }
    }

    /// <summary>
    /// Makes the player jump vertically.
    /// </summary>
    void OnJump()
    {
        if (PlayerMovement == false)
        {
            return;
        }
        if (IsGrounded())
        {
            rb.velocity = new Vector3(0, jumpValue, 0);
            animator.SetBool("Jump", true);
        }
    }

    /// <summary>
    /// Makes the player attack.
    /// </summary>
    void OnAttack()
    {
        if (PlayerMovement == false)
        {
            return;
        }
        animator.SetTrigger("Attack");
        GameObject newsickle = Instantiate(sicklePrefab, transform.position, transform.rotation);
        newsickle.GetComponent<Rigidbody>().velocity = new Vector3(1, 1, 1) * 10;
        if (playerScale.x == -1)
        {
            newsickle.GetComponent<Rigidbody>().velocity = new Vector3(-1, 1, 1) * 10;
            newsickle.GetComponent <SpriteRenderer>().flipX = true;
        }
        else
        {
            newsickle.GetComponent<Rigidbody>().velocity = new Vector3(1, 1, 1) * 10;
        }
    }

    // Calls for the PauseMenu script.
    void OnPause()
    {
        pauseMenu.Pause();
    }

    /// <summary>
    /// Sets the player animation when touching the ground
    /// </summary>
    bool IsGrounded()
    {
        if (Physics.BoxCast(transform.position, Vector3.zero, Vector3.down, Quaternion.identity, BoxCastDistance, 
            jumpMask))
        {

            animator.SetBool("Jump", false);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Moves the player.
    /// </summary>
    IEnumerator ApplyMovement()
    {
        while(true)
        {
            rb.velocity = new Vector3(playerMovement.x * playerSpeed, rb.velocity.y, playerMovement.z * playerSpeed);
            if (rb.velocity == Vector3.zero)
            {
                animator.SetBool("Move", false);
            }
            yield return null;
        }
        
    }

    // Cancels the following actions.
    private void OnDestroy()
    {
        move.started -= Move_started;
        move.canceled -= Move_canceled;
        restart.performed -= Restart_performed;
        quit.performed -= Quit_performed;
    }

    /// <summary>
    /// Returns the player from the jump animation back to the idle animation after completing a jump
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (IsGrounded())
        {
            animator.SetBool("Jump", false);
        }
    }
}
