using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("Sub Behaviours")]
    public PlayerMovementBehaviour playerMovementBehaviour;

    [Header("Input Settings")]
    public PlayerInput playerInput;
    private Vector2 inputMovement;

    //Action Maps
    private string actionMapPlayerControls = "Player Controls"; 
    private string actionMapMenuControls = "Menu Controls";

    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// Input System Action
    /// </summary>
    /// 
    public void OnMovement(InputAction.CallbackContext value)
    {
        inputMovement = value.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerMovement();
    }

    void UpdatePlayerMovement()
    {
        playerMovementBehaviour.UpdateMovementData(inputMovement);
    }
}
