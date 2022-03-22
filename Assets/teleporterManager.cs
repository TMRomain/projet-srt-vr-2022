using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class teleporterManager : MonoBehaviour
{
    [SerializeField] private VRTeleporter vrTeleporter;

    [SerializeField] private ActionBasedController controller;
    
    private void Start()
    {
        vrTeleporter.ToggleDisplay(true);
        bool isPressed = controller.selectAction.action.ReadValue<bool>();
        
        controller.selectAction.action.performed += ActionOnperformed;
    }

    private void ActionOnperformed(InputAction.CallbackContext obj)
    {
        vrTeleporter.Teleport();
    }

}
