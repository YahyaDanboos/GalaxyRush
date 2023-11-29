using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("Component References")]
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;

    [Header("Input Settings")]
    public PlayerInput playerInput;
    private Vector2 inputMovement;

    //Action Maps
    //private string actionMapPlayerControls = "Player Controls"; 
    //private string actionMapMenuControls = "Menu Controls";

    // Start is called before the first frame update
    void Start()
    {

    }

    ////////////////////////
    /// Input System Action
    ////////////////////////
    public void OnMovement(InputAction.CallbackContext value)
    {
        inputMovement = value.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext value)
    {
        if(value.performed)
            playerCombat.Shoot(true);
        else if (value.canceled)
            playerCombat.Shoot(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerMovement();
    }

    void UpdatePlayerMovement()
    {
        playerMovement.UpdateMovementData(inputMovement);
    }
}
