using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
public class playerGlideScript : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private Transform camTransform;
    // Start is called before the first frame update
    void Awake()
    {
        // cam = Camera.main;
        cam2 = GetComponent<XROrigin>().Camera;

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(cam2.transform.rotation.y);
        // Debug.Log(cam.transform.rotation);
        Vector3 dir = cam.transform.forward;
        GetComponent<Rigidbody>().velocity = 10f * dir;
    }
}
