using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    Transform followObject;
    [SerializeField]
    float offsetX = 20F;
    [SerializeField]
    float offsetY = 20F;
    [SerializeField]
    float offsetZ = 0F;

    // Update is called once per frame
    void Update()
    {
        Vector3 changedPos = new Vector3(followObject.position.x + offsetX, followObject.position.y + offsetY, followObject.position.z + offsetZ);
        transform.position = changedPos;
    }
}
