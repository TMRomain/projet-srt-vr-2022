using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    void Update()
    {
        transform.position = camera.transform.position;
    }
}
