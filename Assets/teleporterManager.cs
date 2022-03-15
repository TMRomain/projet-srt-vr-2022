using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporterManager : MonoBehaviour
{
    [SerializeField] private VRTeleporter vrTeleporter;

    private void Start()
    {
        vrTeleporter.ToggleDisplay(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown("Fire1"))
        {
            vrTeleporter.Teleport();
        }
    }
}
