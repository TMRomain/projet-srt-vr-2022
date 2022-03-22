using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private Transform camera;
    [SerializeField] bool cameraControl = true;




    private Rigidbody _rb;
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        //bool isPressed = controller.selectAction.action.ReadValue<bool>(); 
        // if (!cameraControl)
        // {
                
        //     transform.Translate(new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime));

        //     if (Input.GetKey(KeyCode.E))
        //     {
        //         transform.Translate(Vector3.up * (Time.deltaTime * speed));
        //     }

        //     if (Input.GetKey(KeyCode.A))
        //     {
        //         transform.Translate(Vector3.down * (Time.deltaTime * speed));
        //     }

        // }
        // else
        // {
        //     transform.Translate(camera.forward * (Time.deltaTime * speed * vertical));
        //     //_rb.AddForce(camera.forward * (Time.deltaTime * speed * vertical) * 10, ForceMode.Force);
        // }
                       
    }
}