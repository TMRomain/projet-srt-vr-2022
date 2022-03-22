using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class MenuActions : MonoBehaviour
{
    [SerializeField] private Transform playerRightHand;
    [SerializeField] private ActionBasedController controller;

    private void Awake()
    {
        controller.activateAction.action.performed += ActionOnperformed;
    }

    private void ActionOnperformed(InputAction.CallbackContext obj)
    {
        RaycastHit[] hits = Physics.RaycastAll(playerRightHand.position, playerRightHand.forward, 3);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.CompareTag("ButtonUI"))
            {
                Debug.Log("Boutton appuyé !");
            }
        }
    }
}
